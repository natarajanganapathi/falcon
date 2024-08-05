namespace LightningArc.Application.Abstractions.Services;

public class QueryServiceBase<TId, TEntity> : ApplicationServiceBase<TId, TEntity> where TEntity : class, IEntity<TId>, new()
{
    public QueryServiceBase(IServiceProvider serviceProvider) : base(serviceProvider) { }

    public Task<TEntity> GetAsync(TId id, CancellationToken cancellationToken)
    {
        return _repository.GetAsync(id, cancellationToken);
    }

    public Task<long> CountAsync(IQueryRequest request, CancellationToken cancellationToken)
    {
        return _repository.CountAsync(request, cancellationToken);
    }

    public async Task<IList<TEntity>> FindAsync(IQueryRequest request, CancellationToken cancellationToken)
    {
        return await _repository.FindAsync(request, cancellationToken);
    }

    public async Task<IList<JObject>> QueryAsync(IQueryRequest request, CancellationToken cancellationToken)
    {
        return await _repository.QueryAsync(request, cancellationToken);
    }
}