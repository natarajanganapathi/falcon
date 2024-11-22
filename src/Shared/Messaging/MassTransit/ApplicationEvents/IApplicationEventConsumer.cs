namespace Falcon.Messaging.MassTransit.ApplicationEvents;

public interface IApplicationEventConsumer<in TApplicationEvent> : IConsumer<TApplicationEvent> where TApplicationEvent : class, IApplicationEvent { }
