namespace Samples.Falcon.Messaging.Events.IntegrationEvents;

public class MyIntegrationEvent : IntegrationEvent
{
    public MyIntegrationEvent(string eventSource) : base(eventSource) { }
    public required string Message { get; set; }
}
