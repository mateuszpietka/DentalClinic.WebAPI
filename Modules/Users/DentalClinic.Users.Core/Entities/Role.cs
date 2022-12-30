using System.ComponentModel.DataAnnotations.Schema;

namespace DentalClinic.Users.Core.Entities;

public class Role
{
    private const string _administrator = "Administrator"; 
    private const string _doctor = "Doctor";
    private const string _receptionist = "Receptionist";
    private const string _patient = "Patient";

    public Role(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }

    public static string Administrator => _administrator;
    public static string Doctor => _doctor;
    public static string Receptionist => _receptionist;
    public static string Patient => _patient;
}
