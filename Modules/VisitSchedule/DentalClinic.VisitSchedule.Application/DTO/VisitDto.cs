namespace DentalClinic.VisitSchedule.Application.DTO;

public class VisitDto
{
    public long Id { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public bool IsFirstVisit { get; set; }
}
