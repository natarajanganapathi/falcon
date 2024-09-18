namespace Falcon.Messaging.Abstractions;

public interface IDomainEvent : IEvent, INotification
{
    Guid AggregateId { get; set; }
    int Version { get; set; }
    string GetEventType();
}
