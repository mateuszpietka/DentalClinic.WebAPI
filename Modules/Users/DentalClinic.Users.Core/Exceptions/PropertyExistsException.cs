namespace DentalClinic.Users.Core.Exceptions;
public class PropertyExistsException : Exception
{
	public PropertyExistsException(string propertyName)
		:base($"This {propertyName} exists in system,")
	{

	}
}
