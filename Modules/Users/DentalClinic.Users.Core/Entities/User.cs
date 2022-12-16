namespace DentalClinic.Users.Core.Entities;

public class User
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PersonalIdNumber { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Phone { get; set; }
    public bool IsConfirmed { get; set; }
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }
    public virtual Address Address { get; set; }
}
