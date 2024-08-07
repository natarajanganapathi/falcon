namespace Falcon.Domain.Abstractions;

public abstract class Entity<TId> : IEntity<TId>
{
    public required virtual TId Id { get; set; }

    public virtual TId GetId()
    {
        return Id;
    }
}