namespace Samples.Falcon.Messaging.WeatherForecast;

public static class WeatherForecastEndpoints
{
    public static IEndpointRouteBuilder MapApis(this IEndpointRouteBuilder route)
    {
        var group = route.MapGroup("weather-forecast");
        group.MapGet("/", GetAsync)
        .Produces<WeatherForecastModel[]>(StatusCodes.Status200OK)
        .WithName("GetWeatherForecast")
        .WithTags("Weather");
        return group;
    }

    public static async Task<IResult> GetAsync(
        IRequestClient<TestQuery> query,
        CommandPublisher commandPublisher,
        ApplicationEventPublisher appEventPublisher,
        DomainEventPublisher domainEventPublisher,
        IntegrationEventPublisher integrationEventPublisher,
        CancellationToken cancellationToken)
    {
        string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

        await appEventPublisher.Publish(new MyApplicationEvent(Guid.NewGuid().ToString(), typeof(MyApplicationEvent).Name)
        {
            Message = "Hello from the event dispatcher beginning of the request"
        });
        await domainEventPublisher.Publish(new MyDomainEvent(Guid.NewGuid(), 1)
        {
            Message = "Hello from the event dispatcher"
        });
        await integrationEventPublisher.Publish(new MyIntegrationEvent("Sample")
        {
            Message = "Hello from the event dispatcher end of the request"
        });

        await commandPublisher.Publish(new TestCommand { Message = "Hello" });
        var response = await query.GetResponse<TestQueryResponse>(new { Message = "Hello" });

        var forecast = Enumerable.Range(1, response.Message.Value)
            .Select(index =>
            {
                return new WeatherForecastModel
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                );
            })
            .ToArray();
        return Results.Ok(forecast);
    }
}

// app.MapGet("/weatherforecast", async (
//             // ApplicationEventPublisher appEventPublisher,
//             // DomainEventPublisher domainEventPublisher,
//             // IntegrationEventPublisher integrationEventPublisher,
//             CommandPublisher commandPublisher,
//             IRequestClient<TestQuery> _client
//             ) =>
// {