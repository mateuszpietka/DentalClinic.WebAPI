using DentalClinic.Shared.Abstarctions.Exceptions;
using Humanizer;
using System.Collections.Concurrent;
using System.Net;

namespace DentalClinic.Shared.Core.Exceptions;

internal sealed class DefaultExceptionToResponseMapper : IExceptionToResponseMapper
{
    private static readonly ConcurrentDictionary<Type, string> Codes;

    static DefaultExceptionToResponseMapper()
    {
        Codes = new ConcurrentDictionary<Type, string>();
    }

    public DefaultExceptionToResponseMapper()
    {

    }

    public IExceptionResponse Map(Exception exception)
    {
        switch (exception)
        {
            case CustomException ex:
                return new ExceptionResponse(new ErrorDetails(GetErrorCode(ex), ex.Message), ex.StatusCode);
            default:
                return new ExceptionResponse(new ErrorDetails("error", "There was an error."), HttpStatusCode.InternalServerError);
        }
    }

    private static string GetErrorCode(object exception)
    {
        var type = exception.GetType();
        var code = type.Name.Underscore().Replace("_exception", string.Empty);
        return Codes.GetOrAdd(type, code);
    }
}