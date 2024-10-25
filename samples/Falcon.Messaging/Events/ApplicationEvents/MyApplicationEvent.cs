namespace Samples.Falcon.Messaging.Events.ApplicationEvents;

public class MyApplicationEvent : ApplicationEvent
{
    public MyApplicationEvent(string userId, string eventType) : base(userId, eventType) { }
    public required string Message { get; set; }
}
