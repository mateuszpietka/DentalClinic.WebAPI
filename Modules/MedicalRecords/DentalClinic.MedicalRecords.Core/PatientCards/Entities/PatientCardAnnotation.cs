namespace DentalClinic.MedicalRecords.Core.PatientCards.Entities;

public class PatientCardAnnotation
{
    public long Id { get; set; }
    public long PatientCardId { get; set; }
    public long DoctorId { get; set; }
    public DateTime CreationDate { get; set; }
    public string Contents { get; set; }
}