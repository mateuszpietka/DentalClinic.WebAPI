using DentalClinic.Shared.Abstarctions.Exceptions;

namespace DentalClinic.Users.Core.Exceptions;
public class PropertyExistsException : CustomException
{
    public PropertyExistsException(string propertyName)
        : base($"This {propertyName} exists in system,")
    {

    }
}
