namespace Falcon.Messaging.Abstractions;

public interface IIntegrationEvent : IEvent
{
    string EventSource { get; }
}
