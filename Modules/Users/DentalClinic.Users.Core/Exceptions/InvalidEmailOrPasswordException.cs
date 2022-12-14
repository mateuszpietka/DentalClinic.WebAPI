namespace DentalClinic.Users.Core.Exceptions;
public class InvalidEmailOrPasswordException : Exception
{
    public InvalidEmailOrPasswordException() 
        : base("Invalid email or password")
    {

    }
}
