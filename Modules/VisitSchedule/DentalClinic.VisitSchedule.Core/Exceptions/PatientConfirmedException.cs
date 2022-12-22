using DentalClinic.Shared.Abstarctions.Exceptions;

namespace DentalClinic.VisitSchedule.Core.Exceptions;
public class PatientConfirmedException : CustomException
{
    public PatientConfirmedException(string message) 
        : base(message)
    {
    }
}
