namespace DentalClinic.Users.Application.DTO;

public record SignInDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}
