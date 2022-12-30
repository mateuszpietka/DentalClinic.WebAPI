using DentalClinic.MedicalRecords.Core.Toothing.Entities;

namespace DentalClinic.MedicalRecords.Core.Toothing.Services;
public interface IPatientToothService
{
    Task UpdatePatientTeethAsync(IEnumerable<PatientTooth> patientTeeth);
    Task<IEnumerable<PatientTooth>> GetPatietnSickTeeth(long patientId);
    Task<IEnumerable<PatientTooth>> GetPatietnHealthyTeeth(long patientId);
}
