var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddSimpleConsole((options) =>
{
    options.SingleLine = true;
    options.TimestampFormat = "hh:mm:ss ";
});

builder.Services.AddOpenApi();
builder.Services.AddMessaging();

// builder.Services.AddMessaging(cfg =>
// {
//     // cfg.AddApplicationEvent((applicationBusConfigurator) =>
//     // {
//     //     applicationBusConfigurator.UsingInMemory((context, cfg) =>
//     //     {
//     //         cfg.ConfigureEndpoints(context);
//     //     });
//     //     applicationBusConfigurator.AddConsumers(Assembly.GetExecutingAssembly());
//     // });

//     // cfg.AddDomainEvent((domainBusConfigurator) =>
//     // {
//     //     domainBusConfigurator.UsingInMemory((context, cfg) =>
//     //     {
//     //         cfg.ConfigureEndpoints(context);
//     //     });
//     //     domainBusConfigurator.AddConsumers(Assembly.GetExecutingAssembly());
//     // });

//     cfg.AddIntegrationEvent((integrationBusConfigurator) =>
//     {
//         integrationBusConfigurator.UsingInMemory((context, cfg) =>
//         {
//             cfg.ConfigureEndpoints(context);
//         });
//         integrationBusConfigurator.AddConsumers(Assembly.GetExecutingAssembly());
//     });
// });



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", (
            ApplicationEventPublisher appEventPublisher,
            DomainEventPublisher domainEventPublisher,
            IntegrationEventPublisher integrationEventPublisher) =>
{
    appEventPublisher.Publish(new MyApplicationEvent(Guid.NewGuid().ToString(), typeof(MyApplicationEvent).Name)
    {
        Message = "Hello from the event dispatcher beginning of the request"
    });
    domainEventPublisher.Publish(new MyDomainEvent(Guid.NewGuid(), 1)
    {
        Message = "Hello from the event dispatcher"
    });
    integrationEventPublisher.Publish(new MyIntegrationEvent("Sample")
    {
        Message = "Hello from the event dispatcher end of the request"
    });

    var forecast = Enumerable.Range(1, 5)
        .Select(index =>
        {
            return new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            );
        })
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
