namespace Falcon.Infrastructure.Abstractions.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "text/plain";
        context.Response.StatusCode = 500;

        // Log the exception, etc.

        return context.Response.WriteAsync("An unexpected error occurred. Please try again later.");
    }
}

// public class ExceptionHandlingMiddleware
// {
//     protected ExceptionHandlingMiddleware() { }

//     public static void HandleException(IApplicationBuilder app)
//     {
//         app.Run(async context =>
//         {
//             context.Response.StatusCode = 500;
//             context.Response.ContentType = "text/plain";

//             // var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
//             // var exception = exceptionHandlerPathFeature.Error;

//             await context.Response.WriteAsync("An unexpected error occurred. Please try again later.");
//         });
//     }
// }