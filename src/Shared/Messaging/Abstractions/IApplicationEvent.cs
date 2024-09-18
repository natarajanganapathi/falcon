namespace Falcon.Messaging.Abstractions;

public interface IApplicationEvent : IEvent, INotification
{
    string UserId { get; }
    string EventType { get; }
}