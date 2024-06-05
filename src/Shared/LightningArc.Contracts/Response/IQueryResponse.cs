namespace LightningArc.Contracts;

public interface IQueryResponse : IApiResponse
{
    IPageContext? Page { get; set; }
    IEnumerable<object>? Data { get; set; }
}