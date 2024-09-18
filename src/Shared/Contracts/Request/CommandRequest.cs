namespace Falcon.Contracts;

public class CommandRequest<TEntity> : ICommandRequest<TEntity>
{
    public CommandRequest(TEntity? data = default)
    {
        Data = data;
    }
    public TEntity? Data { get; set; }
}