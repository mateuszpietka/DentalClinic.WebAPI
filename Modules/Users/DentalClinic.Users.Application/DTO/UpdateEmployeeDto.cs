namespace DentalClinic.Users.Application.DTO;

public class UpdateEmployeeDto
{
    public long EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string ConfirmePassword { get; set; }
}