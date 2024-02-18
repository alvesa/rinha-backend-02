using System.Text.Json;
using rinha_backend_api.IoC.Dtos;

namespace rinha_backend_api.Filters
{
    public class HttpExceptionHandler
{
    private readonly RequestDelegate _next;

    public HttpExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (RinhaError ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, RinhaError exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = exception.Code;

        var result = new
        {
            Code = context.Response.StatusCode,
            Message = exception.Message
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(result));
    }
}
}