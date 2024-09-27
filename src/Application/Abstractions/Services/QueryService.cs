namespace Falcon.Application.Abstractions.Services;

public class QueryService<TId, TEntity> : ApplicationService<TId, TEntity> where TEntity : class, IEntity<TId>, new()
{
    public QueryService(IServiceProvider serviceProvider) : base(serviceProvider) { }

    public Task<TEntity> GetAsync(TId id, CancellationToken cancellationToken)
    {
        return GetRepository().GetAsync(id, cancellationToken);
    }

    public Task<long> CountAsync(IQueryRequest request, CancellationToken cancellationToken)
    {
        return GetRepository().CountAsync(request, cancellationToken);
    }

    public async Task<IList<TEntity>> FindAsync(IQueryRequest request, CancellationToken cancellationToken)
    {
        return await GetRepository().FindAsync(request, cancellationToken);
    }

    public async Task<IList<JObject>> QueryAsync(IQueryRequest request, CancellationToken cancellationToken)
    {
        return await GetRepository().QueryAsync(request, cancellationToken);
    }
}