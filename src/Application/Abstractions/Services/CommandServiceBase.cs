namespace Falcon.Application.Abstractions.Services;

public class CommandServiceBase<TId, TEntity> : ApplicationServiceBase<TId, TEntity> where TEntity : class, IEntity<TId>, new()
{
    public CommandServiceBase(IServiceProvider serviceProvider) : base(serviceProvider) { }
    public Task<TEntity> CreateAsync(ICommandRequest<TEntity> request, CancellationToken cancellationToken)
    {
        return GetRepository().CreateAsync(request, cancellationToken);
    }

    public Task<TEntity> DeleteAsync(TId id, CancellationToken cancellationToken)
    {
        return GetRepository().DeleteAsync(id, cancellationToken);
    }

    public Task<TEntity> PatchAsync(TId id, ICommandRequest<JsonPatchDocument<TEntity>> request, CancellationToken cancellationToken)
    {
        return GetRepository().PatchAsync(id, request, cancellationToken);
    }

    public Task<TEntity> UpdateAsync(TId id, ICommandRequest<TEntity> request, CancellationToken cancellationToken)
    {
        return GetRepository().UpdateAsync(id, request, cancellationToken);
    }
}