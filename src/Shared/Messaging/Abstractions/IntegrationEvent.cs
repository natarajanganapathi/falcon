namespace Falcon.Messaging.Abstractions;

public abstract class IntegrationEvent : IIntegrationEvent
{
    public Guid Id { get; private set; }
    public DateTime OccurredOn { get; private set; }
    public string EventSource { get; private set; }

    protected IntegrationEvent(string eventSource)
    {
        Id = Guid.NewGuid();
        OccurredOn = DateTime.UtcNow;
        EventSource = eventSource;
    }
}