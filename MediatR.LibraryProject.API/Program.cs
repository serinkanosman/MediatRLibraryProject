using eTicaret.Application;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();

builder.Services.AddTransient(typeof(Test)); // Registering Test class as a service

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", (IServiceProvider serviceProvider) =>
{
    //Use the service provider to resolve the Test class
    var type = typeof(Test);
    var handler = serviceProvider.GetRequiredService(type);
    var result = type.GetMethod("Calculate")!.Invoke(handler, null);
    return result;
});
app.MapPost("/products",
    async (ProductCreateCommand request, ISender sender, CancellationToken cancellationToken) =>
{   // Use the ISender to send the request 
    await sender.Send(request, cancellationToken);
    return new { Message = "Create product is successful" };
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
