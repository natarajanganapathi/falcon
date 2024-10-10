
namespace FalconSample.Events.IntegrationEvents;

public class TestQueryConsumer : IQueryConsumer<TestQuery>
{
    private readonly ILogger _logger;
    public TestQueryConsumer(ILogger<TestQueryConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<TestQuery> context)
    {
        _logger.LogInformation($"Query Consumed: {context.Message.Message}");
        return context.RespondAsync(new TestQueryResponse { Value = 15 });
    }
}