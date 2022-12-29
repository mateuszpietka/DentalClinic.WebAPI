using DentalClinic.Shared.Abstarctions.Exceptions;

namespace DentalClinic.VisitSchedule.Core.Exceptions;
public class PatientUnconfirmedException : CustomException
{
    public PatientUnconfirmedException() 
        : base("Only an confirmed patient can add the next visit")
    {
    }
}
