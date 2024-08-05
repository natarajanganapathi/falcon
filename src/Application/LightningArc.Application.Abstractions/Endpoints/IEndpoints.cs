namespace LightningArc.Application.Abstractions;

public interface IEndpoints
{
    IEndpointRouteBuilder MapApis(IEndpointRouteBuilder route);
}
