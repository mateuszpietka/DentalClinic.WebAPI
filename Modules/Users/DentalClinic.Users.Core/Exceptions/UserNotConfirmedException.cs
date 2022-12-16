using DentalClinic.Shared.Abstarctions.Exceptions;
using System.Net;

namespace DentalClinic.Users.Core.Exceptions;

public class UserNotConfirmedException : CustomException
{
	public UserNotConfirmedException()
		: base("This user is not confirmed")
	{

	}

	public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
}
