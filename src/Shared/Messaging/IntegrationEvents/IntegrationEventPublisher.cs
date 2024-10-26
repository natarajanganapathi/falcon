namespace Falcon.Messaging.IntegrationEvents;

public class IntegrationEventPublisher : IEventPublisher
{
    private readonly IntegrationEventBus _integrationEventBus;

    public IntegrationEventPublisher(IntegrationEventBus integrationEventBus)
    {
        _integrationEventBus = integrationEventBus;
    }

    public Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : class, IEvent
    {
        return _integrationEventBus.Publish(@event, cancellationToken);
    }
}

