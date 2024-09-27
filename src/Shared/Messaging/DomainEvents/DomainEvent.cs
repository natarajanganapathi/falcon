namespace Falcon.Messaging.DomainEvents;

public abstract class DomainEvent : IDomainEvent
{
    public Guid Id { get; set; }
    public DateTime OccurredOn { get; set; }
    public Guid AggregateId { get; set; }
    public int Version { get; set; }

    protected DomainEvent(Guid aggregateId, int version)
    {
        Id = Guid.NewGuid();
        OccurredOn = DateTime.UtcNow;
        AggregateId = aggregateId;
        Version = version;
    }

    public string GetEventType()
    {
        return GetType().Name;
    }
}
