namespace DentalClinic.VisitSchedule.Core.Entities;

public class Visit
{
    public long Id { get; set; }
    public long DoctorId { get; set; }
    public long PatientId { get; set; }
    public DateTime StartDate { get; set; }
    public bool IsFirstVisit { get; set; }
    public int VisitTypeId { get; set; }
    public virtual VisitType VisitType { get; set; }
}