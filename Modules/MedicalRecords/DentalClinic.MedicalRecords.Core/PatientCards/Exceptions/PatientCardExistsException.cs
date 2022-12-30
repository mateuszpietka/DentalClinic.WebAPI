using DentalClinic.Shared.Abstarctions.Exceptions;

namespace DentalClinic.MedicalRecords.Core.PatientCards.Exceptions;
public class PatientCardExistsException : CustomException
{
    public PatientCardExistsException()
        :base("There is a patient card for this patient")
    {

    }
}
