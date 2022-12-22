namespace DentalClinic.VisitSchedule.Application.DTO;

public class PatientVisitScheduleFilterDto
{
    public long PatientId { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
}
