namespace LightningArc.Domain.Abstractions;

public interface IBaseEntity<TId>
{
    public TId Id { get; set; }
}