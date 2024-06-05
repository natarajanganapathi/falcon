namespace LightningArc.Contracts;

public record CommandResponse<TEntity> : ICommandResponse<TEntity>
{
    public CommandResponse(TEntity? data = default)
    {
        Data = data;
    }
    public TEntity? Data { get; set; }
}