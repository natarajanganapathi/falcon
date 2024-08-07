namespace Falcon.Infrastructure.Abstractions;

public class RequestContext<TId> : IRequestContext<TId> where TId : new()
{
    public TId UserId { get; set; } = new();
}
