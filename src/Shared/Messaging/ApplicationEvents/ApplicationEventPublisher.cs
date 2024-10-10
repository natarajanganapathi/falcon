namespace Falcon.Messaging.ApplicationEvents;

public class ApplicationEventPublisher : BusInstance<IApplicationEventBus>, IApplicationEventBus
{
    public ApplicationEventPublisher(IBusControl busControl) : base(busControl) { }
}
