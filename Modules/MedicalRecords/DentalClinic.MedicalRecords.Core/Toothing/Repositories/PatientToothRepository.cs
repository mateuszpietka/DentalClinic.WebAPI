using DentalClinic.MedicalRecords.Core.Toothing.Entities;
using DentalClinic.Shared.Abstarctions.Repostories;

namespace DentalClinic.MedicalRecords.Core.Toothing.Repositories;
public interface IPatientToothRepository : IGenericRepository<PatientTooth, (long patientId, int quadrantCode, int toothNumber)>
{
    Task<IEnumerable<PatientTooth>> GetPatientTeeth(long patientId);
}
