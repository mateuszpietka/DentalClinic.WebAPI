namespace DentalClinic.MedicalRecords.Application.PatientCards.DTO;
public class PatientCardAnnotationDto
{
    public long Id { get; set; }
    public string DoctorFullName { get; set; }
    public DateTime CreationDate { get; set; }
    public string Contents { get; set; }
}
