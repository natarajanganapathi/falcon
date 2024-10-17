
namespace Samples.Falcon.Messaging.Events.IntegrationEvents;

public class MyIntegrationEventConsumer : IIntegrationEventConsumer<MyIntegrationEvent>
{
    private readonly ILogger _logger;
    public MyIntegrationEventConsumer(ILogger<MyIntegrationEventConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<MyIntegrationEvent> context)
    {
        _logger.LogInformation($"Integration Event Consumed: {context.Message.Message}");
        return Task.CompletedTask;
    }
}