namespace DentalClinic.MedicalRecords.Core.Toothing.Entities;
public class PatientTooth
{
    public long PatientId { get; set; }
    public int QuadrantCode { get; set; }
    public int ToothNumber { get; set; }
    public int Condition { get; set; }
}