using DentalClinic.Shared.Abstarctions.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace DentalClinic.Shared.Core.Exceptions;

internal sealed class ErrorHandlerMiddleware : IMiddleware
{
    private readonly IExceptionCompositionRoot _exceptionCompositionRoot;

    public ErrorHandlerMiddleware(IExceptionCompositionRoot exceptionCompositionRoot)
    {
        _exceptionCompositionRoot = exceptionCompositionRoot;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleErrorAsync(context, exception);
        }
    }

    private async Task HandleErrorAsync(HttpContext context, Exception exception)
    {
        var errorResponse = _exceptionCompositionRoot.Map(exception);
        context.Response.StatusCode = (int)(errorResponse?.StatusCode ?? HttpStatusCode.InternalServerError);
        var response = errorResponse?.Response;

        if (response is null)
            return;

        var json = JsonConvert.SerializeObject(response, Formatting.Indented);
        await context.Response.WriteAsync(json);
    }
}