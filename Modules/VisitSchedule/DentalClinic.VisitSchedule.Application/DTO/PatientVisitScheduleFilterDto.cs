namespace DentalClinic.VisitSchedule.Application.DTO;

public class PatientVisitScheduleFilterDto
{
    public long PatientIds { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
}
