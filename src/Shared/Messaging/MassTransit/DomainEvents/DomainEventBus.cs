namespace Falcon.Messaging.MassTransit.DomainEvents;

public class DomainEventBus : BusInstance<IDomainEventBus>, IDomainEventBus
{
    public DomainEventBus(IBusControl busControl) : base(busControl) { }
}