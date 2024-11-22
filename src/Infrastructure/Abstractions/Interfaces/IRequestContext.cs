namespace Falcon.Infrastructure.Abstractions;

public interface IRequestContext
{
    IUserId UserId { get; }
}