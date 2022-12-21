using DentalClinic.Shared.Abstarctions.Exceptions;
using System.Net;

namespace DentalClinic.Shared.Core.Exceptions;

internal record ExceptionResponse(object Response, HttpStatusCode StatusCode) : IExceptionResponse;