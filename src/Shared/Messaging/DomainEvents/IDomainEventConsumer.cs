namespace Falcon.Messaging.DomainEvents;

public interface IDomainEventConsumer<in TDomainEvent> : IConsumer<TDomainEvent> where TDomainEvent : class, IDomainEvent { }
