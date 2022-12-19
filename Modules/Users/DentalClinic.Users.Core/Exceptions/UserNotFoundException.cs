using DentalClinic.Shared.Abstarctions.Exceptions;
using System.Net;

namespace DentalClinic.Users.Core.Exceptions;

public  class UserNotFoundException : CustomException
{
    public UserNotFoundException()
        : base("User not found")
    {

    }

    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}
