namespace Falcon.Contracts;

public record QueryResponse : IQueryResponse
{
    public QueryResponse(IEnumerable<object>? data = default, IPageContext? pc = default)
    {
        Data = data;
        Page = pc;
    }
    public IPageContext? Page { get; set; }
    public IEnumerable<object>? Data { get; set; }
}

public static partial class Extensions
{
    #region QueryResponse
    public static IQueryResponse SetData(this IQueryResponse source, IEnumerable<object> data)
    {
        source.Data = data;
        return source;
    }
    public static IQueryResponse SetPageContext(this IQueryResponse source, IPageContext pc)
    {
        source.Page = pc;
        return source;
    }
    #endregion
}