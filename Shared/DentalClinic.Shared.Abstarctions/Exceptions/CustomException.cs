using System.Net;

namespace DentalClinic.Shared.Abstarctions.Exceptions;

public abstract class CustomException : Exception
{
    protected CustomException(string message) : base(message)
    {
    }

    public virtual HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}