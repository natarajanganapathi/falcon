namespace Falcon.Contracts;

public interface ICompositeResponse : IApiResponse
{
    Dictionary<string, IApiResponse>? Data { get; set; }
}
