var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddSimpleConsole((options) =>
{
    options.SingleLine = true;
    options.TimestampFormat = "hh:mm:ss ";
});

builder.Services.AddOpenApi();
#if DEBUG
    builder.Services.LogQueryConsumers();
#endif

builder.Services.AddMessagingExtension();

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

app.MapGet("/weatherforecast", async (
            // ApplicationEventPublisher appEventPublisher,
            // DomainEventPublisher domainEventPublisher,
            // IntegrationEventPublisher integrationEventPublisher,
            CommandPublisher commandPublisher,
            IRequestClient<TestQuery> _client
            ) =>
{
    // await appEventPublisher.Publish(new MyApplicationEvent(Guid.NewGuid().ToString(), typeof(MyApplicationEvent).Name)
    // {
    //     Message = "Hello from the event dispatcher beginning of the request"
    // });
    // domainEventPublisher.Publish(new MyDomainEvent(Guid.NewGuid(), 1)
    // {
    //     Message = "Hello from the event dispatcher"
    // });
    // integrationEventPublisher.Publish(new MyIntegrationEvent("Sample")
    // {
    //     Message = "Hello from the event dispatcher end of the request"
    // });
    commandPublisher.Publish(new TestCommand { Message = "Hello" });

    //  var client = Bus.Factory.CreateRequestClient<IGetUserQuery>();
    // var response = await client.GetResponse<IUserDetails>(new { UserId = userId });
    // // return response.Message;

    var response = await _client.GetResponse<TestQueryResponse>(new { Message = "Hello" });
    var val = response.Message;

    var forecast = Enumerable.Range(1, val.Value)
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


