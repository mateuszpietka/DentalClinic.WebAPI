using DentalClinic.MedicalRecords.Core.Toothing.Entities;

namespace DentalClinic.MedicalRecords.Core.Toothing.Services;
public interface IPatientToothService
{
    Task UpdatePatientTeethAsync(IEnumerable<PatientTooth> patientTeeth);
}
