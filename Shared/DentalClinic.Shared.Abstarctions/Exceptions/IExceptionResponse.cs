using System.Net;

namespace DentalClinic.Shared.Abstarctions.Exceptions;

public interface IExceptionResponse
{
    public object Response { get; }
    public HttpStatusCode StatusCode { get; }
}