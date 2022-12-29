using DentalClinic.Shared.Abstarctions.Exceptions;
using System.Net;

namespace DentalClinic.Users.Core.Exceptions;
internal class ForbiddenException : CustomException
{
    public ForbiddenException()
        : base("Forbidden")
    {

    }

    public override HttpStatusCode StatusCode => HttpStatusCode.Forbidden;
}