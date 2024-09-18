namespace Falcon.Infrastructure.EntityFramework.Abstractions.Repository;

public class TenantRepository<TId, TEntity> : SqlRepository<TId, TEntity> where TEntity : class, IEntity<TId>, new()
{
    public TenantRepository(IServiceProvider serviceProvider, TenantDbContext dbContext) : base(serviceProvider, dbContext)
    {
    }
}