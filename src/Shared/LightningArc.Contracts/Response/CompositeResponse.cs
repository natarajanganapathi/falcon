namespace LightningArc.Contracts;

public record CompositeResponse : ICompositeResponse
{
    public CompositeResponse(Dictionary<string, IApiResponse>? data = null)
    {
        Data = data;
    }
    public Dictionary<string, IApiResponse>? Data { get; set; }
}