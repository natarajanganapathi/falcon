
namespace FalconSample.Events.IntegrationEvents;

public class TestQueryConsumer2 : IQueryConsumer<TestQuery>
{
    private readonly ILogger _logger;
    public TestQueryConsumer2(ILogger<TestQueryConsumer2> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<TestQuery> context)
    {
        _logger.LogInformation($"Query Consumed2: {context.Message.Message}");
        return context.RespondAsync(new TestQueryResponse { Value = 30 });
    }
}