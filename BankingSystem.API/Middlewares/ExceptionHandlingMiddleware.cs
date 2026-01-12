using BankingSystem.Domain.Exceptions;
using BankingSystem.Shared.Responses;
using System.Net;
using System.Text.Json;

namespace BankingSystem.API.Middlewares;

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

        catch (AccountNotFoundException ex)
        {
            await WriteErrorAsync(context, HttpStatusCode.NotFound, ex.Message);
        }

        catch (DomainException ex)
        {
            await WriteErrorAsync(
                context,
                HttpStatusCode.BadRequest,
                ex.Message
            );
        }
        catch (Exception)
        {
            await WriteErrorAsync(
                context,
                HttpStatusCode.InternalServerError,
                "Unexpected error occurred"
            );
        }
    }

    private static async Task WriteErrorAsync(HttpContext context, HttpStatusCode statusCode, string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var response = ApiResponse<string>.Fail(message);

        await context.Response.WriteAsync(
            JsonSerializer.Serialize(response)
        );
    }
}
