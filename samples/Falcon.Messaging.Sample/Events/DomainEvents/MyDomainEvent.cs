namespace FalconSample.Events.DomainEvents;

public class MyDomainEvent : DomainEvent
{
    public MyDomainEvent(Guid aggregateId, int version) : base(aggregateId, version) { }
    public required string Message { get; set; }
}
