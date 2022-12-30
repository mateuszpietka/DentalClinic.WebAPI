using DentalClinic.MedicalRecords.Core.Toothing.Entities;
using DentalClinic.MedicalRecords.Core.Toothing.Repositories;
using DentalClinic.MedicalRecords.Core.Toothing.Services;

namespace DentalClinic.MedicalRecords.Application.Toothing.Services;
internal class PatientToothService : IPatientToothService
{
    private readonly IPatientToothRepository _patientToothRepository;

    public PatientToothService(IPatientToothRepository patientToothRepository)
    {
        _patientToothRepository = patientToothRepository;
    }

    public async Task UpdatePatientTeethAsync(IEnumerable<PatientTooth> patientTeeth)
    {
        foreach (var patientTooth in patientTeeth)
        {
            var toothToUpdate = await _patientToothRepository.GetByIdAsync((patientTooth.PatientId, patientTooth.QuadrantCode, patientTooth.ToothNumber));

            if (toothToUpdate == null)
            {
                await _patientToothRepository.AddAsync(patientTooth);
                continue;
            }

            toothToUpdate.Condition = patientTooth.Condition;
            await _patientToothRepository.UpdateAsync(toothToUpdate);
        }
    }
}
