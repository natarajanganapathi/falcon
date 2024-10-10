
namespace FalconSample.Events.DomainEvents;

public class MyDomainEventConsumer : IDomainEventConsumer<MyDomainEvent>
{
    private readonly ILogger _logger;
    public MyDomainEventConsumer(ILogger<MyDomainEventConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<MyDomainEvent> context)
    {
        _logger.LogInformation($"Domain Event Consumed: {context.Message.Message}");
        return Task.CompletedTask;
    }
}