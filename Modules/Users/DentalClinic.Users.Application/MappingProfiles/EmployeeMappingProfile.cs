using AutoMapper;
using DentalClinic.Users.Application.DTO;
using DentalClinic.Users.Core.Entities;

namespace DentalClinic.Users.Application.MappingProfiles;
internal class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<User, EmployeeDto>()
            .ForMember(x => x.RoleName, c => c.MapFrom(s => s.Role.Name));
    }
}