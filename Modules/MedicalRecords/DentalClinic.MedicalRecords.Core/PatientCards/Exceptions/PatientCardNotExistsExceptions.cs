using DentalClinic.Shared.Abstarctions.Exceptions;

namespace DentalClinic.MedicalRecords.Core.PatientCards.Exceptions;
public class PatientCardNotExistsExceptions : CustomException
{
    public PatientCardNotExistsExceptions()
        : base("There is no patient card for this patient")
    {

    }
}
