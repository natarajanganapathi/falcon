namespace Falcon.Infrastructure.EntityFramework.Abstractions.Repository;

public class SqlRepositoryProvider : IRepositoryProvider
{
    private readonly IServiceProvider _serviceProvider;
    public SqlRepositoryProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public IRepository<TId, TEntity> GetRepository<TId, TEntity>() where TEntity : class, IEntity<TId>, new()
    {
        var type = typeof(TEntity).GetCustomAttribute<HomeDbAttribute>();
        return type is null
                ? _serviceProvider.GetRequiredService<TenantRepository<TId, TEntity>>()
                : _serviceProvider.GetRequiredService<HomeRepository<TId, TEntity>>();
    }
}
