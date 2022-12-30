using DentalClinic.MedicalRecords.Core.PatientCards.Entities;
using DentalClinic.Shared.Abstarctions.Repostories;

namespace DentalClinic.MedicalRecords.Core.PatientCards.Repositories;
public interface IPatientCardRepository : IGenericRepository<PatientCard, long>
{
    Task<PatientCard> GetByPatientIdAsync(long patientId);
}