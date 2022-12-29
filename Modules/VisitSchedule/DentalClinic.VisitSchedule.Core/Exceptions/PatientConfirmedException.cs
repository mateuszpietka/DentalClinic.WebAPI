using DentalClinic.Shared.Abstarctions.Exceptions;

namespace DentalClinic.VisitSchedule.Core.Exceptions;
public class PatientConfirmedException : CustomException
{
    public PatientConfirmedException() 
        : base("Only an unconfirmed patient can add the first visit")
    {
    }
}
