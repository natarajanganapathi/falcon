namespace Falcon.Domain.Abstractions.Interfaces.Repositories;

public interface IRepository<TId, TEntity> where TEntity : class, IEntity<TId>
{
    Task<IList<TEntity>> FindAsync(IQueryRequest request, CancellationToken cancellationToken = default); // TODO: IAsyncEnumerable<TEntity> instead of Task<IList<TEntity>>
    Task<IList<JObject>> QueryAsync(IQueryRequest request, CancellationToken cancellationToken = default);
    Task<long> CountAsync(IQueryRequest request, CancellationToken cancellationToken = default);
    Task<TEntity> GetAsync(TId id, CancellationToken cancellationToken = default);   
    Task<TEntity> CreateAsync(ICommandRequest<TEntity> request, CancellationToken cancellationToken = default); 
    Task<TEntity> UpdateAsync(TId id, ICommandRequest<TEntity> request, CancellationToken cancellationToken = default);
    Task<TEntity> PatchAsync(TId id, ICommandRequest<JsonPatchDocument<TEntity>> request, CancellationToken cancellationToken = default);
    Task<TEntity> DeleteAsync(TId id, CancellationToken cancellationToken = default);
}
