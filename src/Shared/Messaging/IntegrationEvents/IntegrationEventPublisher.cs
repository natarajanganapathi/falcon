namespace Falcon.Messaging.IntegrationEvents;

public class IntegrationEventPublisher : BusInstance<IIntegrationEventBus>, IIntegrationEventBus
{
    public IntegrationEventPublisher(IBusControl busControl) : base(busControl) { }
}

