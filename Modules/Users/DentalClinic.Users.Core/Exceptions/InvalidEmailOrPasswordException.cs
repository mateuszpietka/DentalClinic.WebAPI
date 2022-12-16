using DentalClinic.Shared.Abstarctions.Exceptions;

namespace DentalClinic.Users.Core.Exceptions;
public class InvalidEmailOrPasswordException : CustomException
{
    public InvalidEmailOrPasswordException() 
        : base("Invalid email or password")
    {

    }
}
