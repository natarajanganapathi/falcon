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
        // QueryClient queryPublisher,
        // CommandSender commandSender,
        // DomainEventPublisher domainEventPublisher,
        // IntegrationEventPublisher integrationEventPublisher,
        // ApplicationEventPublisher applicationEventPublisher,
        CancellationToken cancellationToken)
    {
        string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

        var query = new TestQuery { Message = "Hello Query" };
        TestCommand command = new TestCommand { Message = "Hello Command" };
        var applicationEvent = new MyApplicationEvent(Guid.NewGuid().ToString(), typeof(MyApplicationEvent).Name)
        {
            Message = "Hello App"
        };
        var domainEvent = new MyDomainEvent(Guid.NewGuid(), 1)
        {
            Message = "Hello Domain"
        };
        var integrationEvent = new MyIntegrationEvent("Sample")
        {
            Message = "Hello Integration"
        };

        var response = await query.GetAsync<TestQuery, TestQueryResponse>(cancellationToken);

        await applicationEvent.PublishAsync(cancellationToken);
        await domainEvent.PublishAsync(cancellationToken);
        await integrationEvent.PublishAsync(cancellationToken);
        await command.SendAsync(cancellationToken);

        // var response = await queryPublisher.GetAsync<TestQuery, TestQueryResponse>(query, cancellationToken);
        // await commandSender.SendAsync(command, cancellationToken);
        // await applicationEventPublisher.PublishAsync(applicationEvent, cancellationToken);
        // await domainEventPublisher.PublishAsync(domainEvnt, cancellationToken);
        // await integrationEventPublisher.PublishAsync(integrationEvent, cancellationToken);

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
