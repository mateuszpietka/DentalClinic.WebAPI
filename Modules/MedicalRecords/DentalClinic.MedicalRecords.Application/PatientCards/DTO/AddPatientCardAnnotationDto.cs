namespace DentalClinic.MedicalRecords.Application.PatientCards.DTO;
public class AddPatientCardAnnotationDto
{
    public long PatientId { get; set; }
    public long DoctorId { get; set; }
    public string Contents { get; set; }
}
