namespace Falcon.Application.Abstractions.Services;

public abstract class ApplicationServiceBase<TId, TEntity> where TEntity : class, IEntity<TId>, new()
{
    private readonly IRepository<TId, TEntity> _repository;
    private readonly IServiceProvider _serviceProvider;

    protected ApplicationServiceBase(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        var repositoryProvider = _serviceProvider.GetRequiredService<IRepositoryProvider>();
        _repository = repositoryProvider.GetRepository<TId, TEntity>();
    }

    public IRepository<TId, TEntity> GetRepository() => _repository;

    public TService GetService<TService>() where TService : class
             => _serviceProvider.GetRequiredService<TService>();
}
