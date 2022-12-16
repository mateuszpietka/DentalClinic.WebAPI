using System.Net;

namespace DentalClinic.Shared.Abstarctions.Exceptions;

internal record ExceptionResponse(object Response, HttpStatusCode StatusCode) : IExceptionResponse;