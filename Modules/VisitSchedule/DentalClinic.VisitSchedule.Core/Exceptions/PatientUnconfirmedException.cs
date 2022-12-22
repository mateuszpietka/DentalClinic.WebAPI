using DentalClinic.Shared.Abstarctions.Exceptions;

namespace DentalClinic.VisitSchedule.Core.Exceptions;
public class PatientUnconfirmedException : CustomException
{
    public PatientUnconfirmedException(string message) 
        : base(message)
    {
    }
}
