namespace Falcon.Messaging.MassTransit.Query;

public interface IQueryConsumer<in TEntity> : IConsumer<TEntity> where TEntity : class, IQuery
{
}
