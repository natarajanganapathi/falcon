namespace LightningArc.Contracts;

public class CompositeRequest : ICompositeRequest
{
    public CompositeRequest()
    {
        Requests = [];
    }
    public Dictionary<string, IApiRequest>? Requests { get; set; }
}

public static partial class Extensions
{
    #region CompositeRequest
    public static ICompositeRequest Add(this ICompositeRequest source, string key, IApiRequest value)
    {
        (source.Requests ??= []).Add(key, value);
        return source;
    }
    #endregion
}