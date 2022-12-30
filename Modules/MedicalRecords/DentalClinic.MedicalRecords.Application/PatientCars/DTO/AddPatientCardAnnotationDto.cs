namespace DentalClinic.MedicalRecords.Application.PatientCars.DTO;
public class AddPatientCardAnnotationDto
{
    public long PatientId { get; set; }
    public long DoctorId { get; set; }
    public string Contents { get; set; }
}
