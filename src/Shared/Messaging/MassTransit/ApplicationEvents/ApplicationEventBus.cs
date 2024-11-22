namespace Falcon.Messaging.MassTransit.ApplicationEvents;

public class ApplicationEventBus : BusInstance<IApplicationEventBus>, IApplicationEventBus
{
    public ApplicationEventBus(IBusControl busControl) : base(busControl) { }
}
