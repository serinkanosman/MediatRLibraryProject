using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MediatR
{
    public interface IRequest { }
    public interface IRequestHandler<TRequest> where TRequest : IRequest
    {
        Task Handle(TRequest request, CancellationToken cancellationToken);
    }

    public interface ISender
    {
        Task Send(IRequest request, CancellationToken cancellationToken = default);
    }
    public sealed class Sender(
        IServiceProvider serviceProvider) : ISender
    {
        public async Task Send(IRequest request, CancellationToken cancellation = default)
        {
            var type = typeof(IRequestHandler<>).MakeGenericType(request.GetType());
            //IRequestHandler<ProductCreateCommand> 
            using (var scoped = serviceProvider.CreateScope())
            {
                var handler = scoped.ServiceProvider.GetRequiredService(type);
                await (Task)type.GetMethod("Handle")!
                    .Invoke(handler, new object[] {request, cancellation})!;
            }
                Console.WriteLine();
        }
    }
}

//Extensions class

public static class MediatRExtensions
{
    public static IServiceCollection AddMediatR(this IServiceCollection services,Assembly assembly)
    {
        var types = assembly.GetTypes().Where(t => !t.IsInterface && !t.IsAbstract);
        var handlerTypes = types.Select(t => t
        .GetInterfaces()
        .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<>))
        .Select(s => new { Interface = s, Impelementation = t }));

        services.AddTransient<ISender, Sender>();
       // services.AddTransient<IRequestHandler<ProductCreateCommand>, ProductCreateCommandHandler>();
        return services;
    }
}