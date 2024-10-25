namespace Falcon.Messaging.DomainEvents;

public class DomainEventBus : BusInstance<IDomainEventBus>, IDomainEventBus
{
    public DomainEventBus(IBusControl busControl) : base(busControl) { }
}