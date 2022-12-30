namespace DentalClinic.MedicalRecords.Application.PatientCars.DTO;

public class PatientCardDto
{
    public long Id { get; set; }
    public string PatientFullName { get; set; }
    public PatientCardAnnotationDto[] PatientCardAnnotations { get; set; }
}