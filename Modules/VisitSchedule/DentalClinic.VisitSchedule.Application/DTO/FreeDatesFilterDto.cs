namespace DentalClinic.VisitSchedule.Application.DTO;
public class FreeDatesFilterDto
{
    public long DoctorId { get; set; }
    public int VisitTypeId { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
}
