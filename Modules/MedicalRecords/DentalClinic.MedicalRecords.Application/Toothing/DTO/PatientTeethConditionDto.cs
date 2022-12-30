namespace DentalClinic.MedicalRecords.Application.Toothing.DTO;
public class PatientTeethConditionDto
{
    public PatientTeethConditionDto()
    {
        HealthyTeeth = Array.Empty<ToothDto>();
        SickTeeth = Array.Empty<ToothDto>();
    }

    public PatientTeethConditionDto(ToothDto[] healthyTeeth, ToothDto[] sickTeeth)
    {
        HealthyTeeth = healthyTeeth;
        SickTeeth = sickTeeth;
    }

    public ToothDto[] HealthyTeeth { get; set; }
    public ToothDto[] SickTeeth { get; set; }
}
