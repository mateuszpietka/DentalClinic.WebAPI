using DentalClinic.MedicalRecords.Core.Toothing.Entities;
using DentalClinic.MedicalRecords.Core.Toothing.Repositories;
using DentalClinic.Shared.Abstarctions.Repostories;
using DentalClinic.Shared.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Shared.Infrastructure.MedicalRecordsModule.Toothing.Repositories;
internal class PatientToothRepository :GenericRepositoryBase<PatientTooth, (long patientId, int quadrantCode, int toothNumber)>, IPatientToothRepository
{
    public PatientToothRepository(DentalClinicDbContext context)
        : base(context)
    {

    }

    public override async Task<PatientTooth> GetByIdAsync((long patientId, int quadrantCode, int toothNumber) id)
    {
        return await _table.FirstOrDefaultAsync(x => x.PatientId == id.patientId && x.QuadrantCode == id.quadrantCode && x.ToothNumber == id.toothNumber);
    }

    public async Task<IEnumerable<PatientTooth>> GetPatientTeethAsync(long patientId)
    {
        return await _table.Where(x => x.PatientId == patientId).ToListAsync();
    }
}
