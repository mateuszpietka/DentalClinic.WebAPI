namespace DentalClinic.VisitSchedule.Application.DTO;
public class VisitDetailsDto
{
    public long PatientId { get; set; }
    public string PatientName { get; set; }
    public string VisitType { get; set; }
    public DateTime StartDate { get; set; }
    public bool IsFirstVisit { get; set; }
}
