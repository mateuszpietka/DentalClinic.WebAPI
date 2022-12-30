namespace DentalClinic.MedicalRecords.Application.Toothing.DTO;
public class MarkTeethDto
{
    public long PatientId { get; set; }
    public ToothDto[] Teeth { get; set; }
}