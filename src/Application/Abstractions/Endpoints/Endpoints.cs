namespace Falcon.Application.Abstractions;

public abstract class Endpoints<TId, TEntity> : IEndpoints where TEntity : class, IEntity<TId>, IAggregateRoot, new()
{
    public virtual IEndpointRouteBuilder MapApi(IEndpointRouteBuilder route) { return route; }
    public abstract string Route { get; }

    public IEndpointRouteBuilder MapApis(IEndpointRouteBuilder route)
    {
        var group = route.MapGroup(Route);
        group.MapGet("/{id}", GetAsync);
        return MapApi(group);
    }

    public async Task<Results<Ok<TEntity>, NotFound>> GetAsync(TId id, [FromServices] QueryServiceBase<TId, TEntity> service, CancellationToken cancellationToken)
    {
        var item = await service.GetAsync(id, cancellationToken);
        return item is null ? TypedResults.NotFound() : TypedResults.Ok(item);
    }
}
