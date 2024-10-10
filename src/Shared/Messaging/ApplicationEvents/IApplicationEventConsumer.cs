namespace Falcon.Messaging.ApplicationEvents;

public interface IApplicationEventConsumer<in TApplicationEvent> : IConsumer<TApplicationEvent> where TApplicationEvent : class, IApplicationEvent { }
