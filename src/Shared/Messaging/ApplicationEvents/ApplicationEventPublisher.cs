namespace Falcon.Messaging.ApplicationEvents;

public class ApplicationEventPublisher : IEventPublisher
{
    private readonly IApplicationEventBus _applicationEventBus;

    public ApplicationEventPublisher(ApplicationEventBus applicationEventBus)
    {
        _applicationEventBus = applicationEventBus;
    }

    public Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : class, IEvent
    {
        return _applicationEventBus.Publish(@event, cancellationToken);
    }
}
