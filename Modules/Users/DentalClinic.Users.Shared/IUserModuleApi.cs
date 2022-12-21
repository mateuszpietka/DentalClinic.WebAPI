using DentalClinic.Users.Shared.DTO;

namespace DentalClinic.Users.Shared;
public interface IUserModuleApi
{
    Task<DoctorDto> GetDoctorAsync(long id);
    Task<PatientDto> GetPatientAsync(long id);
}
