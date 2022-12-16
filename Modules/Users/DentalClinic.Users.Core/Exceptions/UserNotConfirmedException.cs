namespace DentalClinic.Users.Core.Exceptions;

public class UserNotConfirmedException : Exception
{
	public UserNotConfirmedException()
		: base("This user is not confirmed")
	{

	}
}
