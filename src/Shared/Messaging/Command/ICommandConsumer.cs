namespace Falcon.Messaging.Command;

public interface ICommandConsumer<in TEntity> : IConsumer<TEntity> where TEntity : class, ICommand
{
}
