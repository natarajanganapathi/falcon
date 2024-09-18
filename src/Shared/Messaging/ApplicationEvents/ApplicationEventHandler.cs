namespace Falcon.Messaging.ApplicationEvents;

public abstract class ApplicationEventHandler<TApplicationEvent> : INotificationHandler<TApplicationEvent>
    where TApplicationEvent : IApplicationEvent
{
    public abstract Task Handle(TApplicationEvent notification, CancellationToken cancellationToken);
}
