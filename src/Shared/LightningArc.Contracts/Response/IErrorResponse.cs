namespace LightningArc.Contracts;

public interface IErrorResponse : IApiResponse
{
    string? Code { get; set; }
    string? Message { get; set; }
    string? StackTrace { get; set; }
}
