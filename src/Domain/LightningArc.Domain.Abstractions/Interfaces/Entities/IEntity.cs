namespace LightningArc.Domain.Abstractions.Interfaces.Entities;

public interface IEntity<TId>
{
    public TId Id { get; set; }
}