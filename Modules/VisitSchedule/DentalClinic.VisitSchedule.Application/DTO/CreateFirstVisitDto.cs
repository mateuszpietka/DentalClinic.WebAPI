namespace DentalClinic.VisitSchedule.Application.DTO;

public class CreateFirstVisitDto
{
    public long PatientId { get; set; }
    public long DoctorId { get; set; }
    public DateTime StartDate { get; set; }
    public int VisitTypeId { get; set; }
}
