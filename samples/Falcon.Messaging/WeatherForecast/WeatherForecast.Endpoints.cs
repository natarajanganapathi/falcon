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
        QueryClient query,
        CommandPublisher command,
        ApplicationEventPublisher applicationEvent,
        DomainEventPublisher domainEvent,
        IntegrationEventPublisher integrationEvent,
        CancellationToken cancellationToken)
    {
        string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

        var response = await query.GetAsync<TestQuery, TestQueryResponse>(new { Message = "Hello" });
        await command.Publish(new TestCommand { Message = "Hello" });

        await applicationEvent.Publish(new MyApplicationEvent(Guid.NewGuid().ToString(), typeof(MyApplicationEvent).Name)
        {
            Message = "Hello from the event dispatcher beginning of the request"
        });
        await domainEvent.Publish(new MyDomainEvent(Guid.NewGuid(), 1)
        {
            Message = "Hello from the event dispatcher"
        });
        await integrationEvent.Publish(new MyIntegrationEvent("Sample")
        {
            Message = "Hello from the event dispatcher end of the request"
        });

        var forecast = Enumerable.Range(1, response.Value)
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
