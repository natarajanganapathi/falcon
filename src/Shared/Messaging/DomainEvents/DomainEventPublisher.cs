namespace Falcon.Messaging.DomainEvents;

public class DomainEventPublisher : BusInstance<IDomainEventBus>, IDomainEventBus
{
    public DomainEventPublisher(IBusControl busControl) : base(busControl) { }
}