﻿namespace DentalClinic.Users.Application.DTO;

public class PatientDetailsDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PersonalIdNumber { get; set; }
    public string Email { get; set; }
    public bool IsConfirmed { get; set; }
    public string Phone { get; set; }
    public string Street { get; set; }
    public string HouseNumber { get; set; }
    public string ApartamentNumber { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
}