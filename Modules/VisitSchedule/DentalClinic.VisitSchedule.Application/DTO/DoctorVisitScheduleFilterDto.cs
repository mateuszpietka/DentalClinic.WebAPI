namespace DentalClinic.VisitSchedule.Application.DTO;

public class DoctorVisitScheduleFilterDto
{
    public long DoctorId { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
}
