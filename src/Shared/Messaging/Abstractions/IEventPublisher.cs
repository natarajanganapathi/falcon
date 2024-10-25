namespace Falcon.Messaging.Abstractions;

public interface IEventPublisher
{
    Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
                        where TEvent : class, IEvent;
}
