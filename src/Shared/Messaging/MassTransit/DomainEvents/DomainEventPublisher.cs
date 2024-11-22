namespace Falcon.Messaging.MassTransit.DomainEvents;

public class DomainEventPublisher : IEventPublisher
{
    private readonly DomainEventBus _domainEventBus;

    public DomainEventPublisher(DomainEventBus domainEventBus)
    {
        _domainEventBus = domainEventBus;
    }

    public Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : class, IEvent
    {
        return _domainEventBus.Publish(@event, cancellationToken);
    }
}
