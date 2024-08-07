namespace Falcon.Infrastructure.EntityFramework;

public class HomeRepository<TId, TEntity> : SqlRepository<TId, TEntity> where TEntity : class, IEntity<TId>, new()
{
    public HomeRepository(IServiceProvider serviceProvider, HomeDbContext dbContext) : base(serviceProvider, dbContext)
    {
    }
}