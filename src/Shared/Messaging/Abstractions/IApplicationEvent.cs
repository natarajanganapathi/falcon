namespace Falcon.Messaging.Abstractions;

public interface IApplicationEvent : IEvent
{
    string UserId { get; }
    string EventType { get; }
}