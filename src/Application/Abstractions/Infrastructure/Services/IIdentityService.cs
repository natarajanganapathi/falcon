namespace Falcon.Application.Abstractions.Infrastructure.Services;

public interface IIdentityService
{
    string? GetUserIdentity();
    string? GetUserName();
}

