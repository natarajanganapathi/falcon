namespace LightningArc.Persistence.Abstractions;

public static class EntityExtentions
{
    public static TEntity Auditable<TId, TEntity>(this TEntity entity, TId userId, DateTime currentTime, bool isCreate = false) where TEntity : class, IEntity<TId>
    {
        if (entity is IAuditableEntity<TId> obj)
        {
            if (isCreate)
            {
                obj.CreatedAtUtc = currentTime;
                obj.CreatedByUserId = userId;
            }
            obj.ModifiedAtUtc = currentTime;
            obj.ModifiedByUserId = userId;
        }
        return entity;
    }
}