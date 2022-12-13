namespace DentalClinic.Users.Core.Entities;

public class Address
{
    public int Id { get; set; }
    public string Street { get; set; }
    public string HouseNumber { get; set; }
    public string ApartamentNumber { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public virtual User User { get; set; }
}
