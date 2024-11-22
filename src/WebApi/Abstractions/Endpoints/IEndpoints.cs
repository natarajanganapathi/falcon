namespace Falcon.Application.Abstractions;

public interface IEndpoints
{
    IEndpointRouteBuilder MapApis(IEndpointRouteBuilder route);
}
