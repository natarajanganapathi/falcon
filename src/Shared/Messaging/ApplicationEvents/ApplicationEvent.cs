namespace Falcon.Messaging.ApplicationEvents;

public abstract class ApplicationEvent : IApplicationEvent
{
    public Guid Id { get; private set; }
    public DateTime OccurredOn { get; private set; }
    public string UserId { get; private set; }
    public string EventType { get; private set; }

    protected ApplicationEvent(string userId, string eventType)
    {
        Id = Guid.NewGuid();
        OccurredOn = DateTime.UtcNow;
        UserId = userId;
        EventType = eventType;
    }
}
