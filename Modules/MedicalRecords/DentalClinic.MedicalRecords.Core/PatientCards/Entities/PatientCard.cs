namespace DentalClinic.MedicalRecords.Core.PatientCards.Entities;
public class PatientCard
{
    public long Id { get; set; }
    public long PatientId { get; set; }
    public virtual ICollection<PatientCardAnnotation> PatientCardAnnotations { get; set; }
}
