// namespace Falcon.Infrastructure.Abstractions;

// public class BaseService<TId, TEntity> where TEntity : class, IEntity<TId>, new()
// {
//     private readonly IRepository<TId, TEntity> _repository;
//     private readonly IServiceProvider _serviceProvider;

//     public BaseService(IServiceProvider serviceProvider)
//     {
//         _serviceProvider = serviceProvider;
//         var repositoryProvider = _serviceProvider.GetRequiredService<IRepositoryProvider>();
//         _repository = repositoryProvider.GetRepository<TId, TEntity>();
//     }
//     public IRepository<TId, TEntity> GetRepository() => _repository;
//     public TService GetService<TService>() where TService : class
//              => _serviceProvider.GetRequiredService<TService>();

//     public Task<TEntity> CreateAsync(ICommandRequest<TEntity> request, CancellationToken cancellationToken)
//     {
//         return _repository.CreateAsync(request, cancellationToken);
//     }

//     public Task<TEntity> DeleteAsync(TId id, CancellationToken cancellationToken)
//     {
//         return _repository.DeleteAsync(id, cancellationToken);
//     }

//     public Task<TEntity> GetAsync(TId id, CancellationToken cancellationToken)
//     {
//         return _repository.GetAsync(id, cancellationToken);
//     }

//     public Task<long> CountAsync(IQueryRequest request, CancellationToken cancellationToken)
//     {
//         return _repository.CountAsync(request, cancellationToken);
//     }

//     public async Task<IList<TEntity>> FindAsync(IQueryRequest request, CancellationToken cancellationToken)
//     {
//         return await _repository.FindAsync(request, cancellationToken);
//     }
//     public async Task<IList<JObject>> QueryAsync(IQueryRequest request, CancellationToken cancellationToken)
//     {
//         return await _repository.QueryAsync(request, cancellationToken);
//     }

//     public Task<TEntity> PatchAsync(TId id, ICommandRequest<JsonPatchDocument<TEntity>> request, CancellationToken cancellationToken)
//     {
//         return _repository.PatchAsync(id, request, cancellationToken);
//     }

//     public Task<TEntity> UpdateAsync(TId id, ICommandRequest<TEntity> request, CancellationToken cancellationToken)
//     {
//         return _repository.UpdateAsync(id, request, cancellationToken);
//     }
// }
