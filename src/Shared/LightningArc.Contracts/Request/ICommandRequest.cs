namespace LightningArc.Contracts;

public interface ICommandRequest<TEntity> : IApiRequest
{
    TEntity? Data { get; set; }
}