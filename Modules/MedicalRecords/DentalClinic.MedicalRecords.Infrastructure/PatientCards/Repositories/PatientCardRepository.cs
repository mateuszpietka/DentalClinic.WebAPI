using DentalClinic.MedicalRecords.Core.PatientCards.Entities;
using DentalClinic.MedicalRecords.Core.PatientCards.Repositories;
using DentalClinic.MedicalRecords.Infrastructure.Context;
using DentalClinic.Shared.Abstarctions.Repostories;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.MedicalRecords.Infrastructure.PatientCards.Repositories;
internal class PatientCardRepository : GenericRepositoryBase<PatientCard, long>, IPatientCardRepository
{
    public PatientCardRepository(MedicalRecordsDbContext context)
        : base(context)
    {

    }

    public async Task<PatientCard> GetByPatientIdAsync(long patientId)
    {
        return await _table.Include(x => x.PatientCardAnnotations).FirstOrDefaultAsync(x => x.PatientId == patientId);
    }
}
