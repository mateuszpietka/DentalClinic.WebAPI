namespace DentalClinic.VisitSchedule.Application.DTO;

public class ReceptionistVisitScheduleFilterDto
{
    public long[] PatientIds { get; set; }
    public long DoctorId { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
}