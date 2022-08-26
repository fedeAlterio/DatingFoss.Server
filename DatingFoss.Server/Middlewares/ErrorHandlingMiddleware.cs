using DatingFoss.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace DatingFoss.Server.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        this._next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (DatingFossException ex)
        {
            await WriteErrorResult(context, HttpStatusCode.BadRequest, ex.Message);
        }
        catch(OperationCanceledException e)
        {
            Console.WriteLine(e.Message + "\n" + e.StackTrace);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message + "\n" + e.StackTrace);
            await WriteErrorResult(context, HttpStatusCode.InternalServerError, e.Message);
        }
    }


    private static Task WriteErrorResult(HttpContext context, HttpStatusCode code, string message)
    {
        string result = JsonSerializer.Serialize(new { error = message });

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(result);
    }
}
