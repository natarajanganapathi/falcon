namespace Falcon.Messaging.IntegrationEvents;

public interface IIntegrationEventConsumer<in TIntegrationEvent> : IConsumer<TIntegrationEvent> where TIntegrationEvent : class, IIntegrationEvent { }