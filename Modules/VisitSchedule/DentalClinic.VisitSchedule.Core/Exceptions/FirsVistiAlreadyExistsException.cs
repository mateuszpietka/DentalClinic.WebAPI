using DentalClinic.Shared.Abstarctions.Exceptions;

namespace DentalClinic.VisitSchedule.Core.Exceptions;
public class FirsVistiAlreadyExistsException : CustomException
{
    public FirsVistiAlreadyExistsException() 
        : base("The patient has already added the first visi")
    {
    }
}
