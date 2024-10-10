namespace Falcon.Infrastructure.Abstractions;

public static class EntityAuditExtensions
{
    public static TEntity AuditForCreate<TId, TEntity>(this TEntity entity, TId userId, DateTime currentTime) where TEntity : class, IEntity<TId>
    {
        if (entity is IAuditableEntity<TId> obj)
        {
            obj.CreatedAtUtc = currentTime;
            obj.CreatedByUserId = userId;
        }
        return entity;
    }
    public static TEntity AuditForUpdate<TId, TEntity>(this TEntity entity, TId userId, DateTime currentTime) where TEntity : class, IEntity<TId>
    {
        if (entity is IAuditableEntity<TId> obj)
        {
            obj.ModifiedAtUtc = currentTime;
            obj.ModifiedByUserId = userId;
        }
        return entity;
    }
}