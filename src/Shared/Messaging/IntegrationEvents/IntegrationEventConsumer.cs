namespace Falcon.Messaging.IntegrationEvents;

public abstract class IntegrationEventConsumer<TIntegrationEvent> : IConsumer<TIntegrationEvent> where TIntegrationEvent : class, IIntegrationEvent
{
    public abstract Task Consume(ConsumeContext<TIntegrationEvent> context);
}