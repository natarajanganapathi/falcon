namespace Falcon.Contracts;

public record ErrorResponse : IErrorResponse
{
    public string? Message { get; set; }
    public string? Code { get; set; }
    public string? StackTrace { get; set; }
}

public static class ExceptionExtension
{
    public static ErrorResponse SetMessage(this ErrorResponse error, string message)
    {
        error.Message = message;
        return error;
    }
    public static ErrorResponse SetCode(this ErrorResponse error, string code)
    {
        error.Code = code;
        return error;
    }
    public static ErrorResponse SetStackTrace(this ErrorResponse error, string stackTrace)
    {
#if DEBUG
        error.StackTrace = stackTrace;
#endif
        return error;
    }

    public static ErrorResponse SetFromException(this ErrorResponse error, Exception ex)
    {
        error.SetMessage(ex.Message);
        error.SetStackTrace(ex.GetInnerStackTrace());
        return error;
    }
    public static string GetInnerStackTrace(this Exception? exception)
    {
        var sb = new StringBuilder();
        int level = 0;
        while (exception != null)
        {
            sb.Append("Level: ").Append(level)
              .Append(", Exception: ").Append(exception.Message)
              .Append(", StackTrace: ").Append(exception.StackTrace)
              .Append(Environment.NewLine);

            level++; // Increment level after appending to StringBuilder
            exception = exception.InnerException; // Move to the next inner exception
        }
        return sb.ToString();
    }
}
