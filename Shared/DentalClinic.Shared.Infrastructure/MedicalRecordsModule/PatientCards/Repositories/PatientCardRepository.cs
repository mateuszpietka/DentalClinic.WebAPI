using DentalClinic.MedicalRecords.Core.PatientCards.Entities;
using DentalClinic.MedicalRecords.Core.PatientCards.Repositories;
using DentalClinic.Shared.Abstarctions.Repostories;
using DentalClinic.Shared.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Shared.Infrastructure.MedicalRecordsModule.PatientCards.Repositories;
internal class PatientCardRepository : GenericRepositoryBase<PatientCard,long>, IPatientCardRepository
{
    public PatientCardRepository(DentalClinicDbContext context)
        : base(context)
    {

    }

    public async Task<PatientCard> GetByPatientIdAsync(long patientId)
    {
        return await _table.Include(x=>x.PatientCardAnnotations).FirstOrDefaultAsync(x=>x.PatientId == patientId);
    }
}
