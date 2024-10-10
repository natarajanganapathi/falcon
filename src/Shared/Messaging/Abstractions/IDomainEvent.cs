namespace Falcon.Messaging.Abstractions;

public interface IDomainEvent : IEvent
{
    Guid AggregateId { get; set; }
    int Version { get; set; }
    string GetEventType();
}
