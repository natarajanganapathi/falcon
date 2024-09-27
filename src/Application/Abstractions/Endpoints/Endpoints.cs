namespace Falcon.Application.Abstractions;

public abstract class Endpoints<TId, TEntity> : IEndpoints where TEntity : class, IEntity<TId>, IAggregateRoot, new()
{
    public abstract string Route { get; }
    public IEndpointRouteBuilder MapApis(IEndpointRouteBuilder route)
    {
        var group = route.MapGroup(Route);
        return MapDefaultApis(group);
    }
    public virtual IEndpointRouteBuilder MapDefaultApis(IEndpointRouteBuilder group)
    {
        // group.MapPost("/", PostAsync);
        group.MapGet("/{id}", GetAsync);
        // group.MapPut("/{id}", PutAsync);
        // group.MapDelete("/{id}", DeleteAsync);
        // group.MapPatch("/{id}", PatchAsync);
        return group;
    }

    public async Task<Results<Ok<TEntity>, NotFound>> GetAsync(TId id, [FromServices] QueryService<TId, TEntity> service, CancellationToken cancellationToken)
    {
        var item = await service.GetAsync(id, cancellationToken);
        return item is null ? TypedResults.NotFound() : TypedResults.Ok(item);
    }
}
