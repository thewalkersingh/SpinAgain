using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace SpinAgain.Web.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
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

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        LogError(ex);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500;

        var response = ConstructProblemDetails(ex);
        var json = SerializeProblemDetails(response);
        await context.Response.WriteAsync(json);
    }

    private void LogError(Exception ex)
    {
        _logger.LogError(ex, ex.Message);
    }

    private ProblemDetails ConstructProblemDetails(Exception ex)
    {
        return new ProblemDetails
        {
            Status = 500,
            Detail = _env.IsDevelopment() ? ex.StackTrace?.ToString() : null,
            Title = ex.Message,
        };
    }

    private string SerializeProblemDetails(ProblemDetails problemDetails)
    {
        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        return JsonSerializer.Serialize(problemDetails, options);
    }
}
