namespace Falcon.Messaging.MassTransit.DomainEvents;

public interface IDomainEventConsumer<in TDomainEvent> : IConsumer<TDomainEvent> where TDomainEvent : class, IDomainEvent { }
