namespace Falcon.Infrastructure.Abstractions;

public class RequestContext : IRequestContext
{
    public RequestContext(IUserId userId)
    {
        UserId = userId;
    }
    public IUserId UserId { get; set; }
}
