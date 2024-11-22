namespace Falcon.Messaging.MassTransit.ApplicationEvents;

public class ApplicationEventPublisher : IEventPublisher
{
    private readonly ApplicationEventBus _applicationEventBus;

    public ApplicationEventPublisher(ApplicationEventBus applicationEventBus)
    {
        _applicationEventBus = applicationEventBus;
    }

    public Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : class, IEvent
    {
        return _applicationEventBus.Publish(@event, cancellationToken);
    }
}
