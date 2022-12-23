namespace DentalClinic.VisitSchedule.Application.DTO;

public class FreeDatesDto
{
	public FreeDatesDto(DateTime[] freeDates)
	{
		FreeDates= freeDates;
	}

    public DateTime[] FreeDates { get; set; }
}
