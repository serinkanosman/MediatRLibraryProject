using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Application
{
    public static class ServiceRegistrar
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistrar).Assembly);
            services.AddTransient<ISender, Sender>();
            services.AddTransient<IRequestHandler<ProductCreateCommand>, ProductCreateCommandHandler>();
            //services.AddMediatR(cfg =>
            //{
            //    cfg.RegisterServicesFromAssembly(typeof(ServiceRegistrar).Assembly());
            //});
            return services;
        }
    }
}
