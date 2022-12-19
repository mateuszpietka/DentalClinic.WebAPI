namespace DentalClinic.Users.Application.DTO;

public class CreateEmployeeDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmePassword { get; set; }
    public string RoleName { get; set; }
}