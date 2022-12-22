namespace DentalClinic.Users.Shared.DTO;

public class PatientDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PersonalIdNumber { get; set; }
    public string Email { get; set; }
    public bool IsConfirmed { get; set; }
}