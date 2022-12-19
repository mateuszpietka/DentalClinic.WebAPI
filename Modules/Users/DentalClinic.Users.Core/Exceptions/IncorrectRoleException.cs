using DentalClinic.Shared.Abstarctions.Exceptions;

namespace DentalClinic.Users.Core.Exceptions;
public class IncorrectRoleException : CustomException
{
    public IncorrectRoleException()
        : base("This role is incorrect. You can use 'Doctor' or 'Receptionist'")
    {

    }
}
