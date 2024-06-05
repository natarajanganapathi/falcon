namespace LightningArc.Contracts;

public interface IQueryRequest : IApiRequest
{
    string[]? Select { get; set; }
    Include[]? Includes { get; set; }
    Filter? Where { get; set; }
    Sort[]? Sort { get; set; }
    PageContext? Page { get; set; }
}