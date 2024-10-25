namespace Falcon.Messaging.IntegrationEvents;

public class IntegrationEventBus : BusInstance<IIntegrationEventBus>, IIntegrationEventBus
{
    public IntegrationEventBus(IBusControl busControl) : base(busControl) { }
}

