using AutoMapper;
using DentalClinic.Users.Application.DTO;
using DentalClinic.Users.Core.Entities;

namespace DentalClinic.Users.Application.MappingProfiles;
internal class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, EmployeeDto>()
            .ForMember(x => x.RoleName, c => c.MapFrom(s => s.Role.Name));

        CreateMap<User, PatientDto>();

        CreateMap<User, PatientDetailsDto>()
            .ForMember(x => x.Street, c => c.MapFrom(s => s.Address != null ? s.Address.Street : string.Empty))
            .ForMember(x => x.HouseNumber, c => c.MapFrom(s => s.Address != null ? s.Address.HouseNumber : string.Empty))
            .ForMember(x => x.ApartamentNumber, c => c.MapFrom(s => s.Address != null ? s.Address.ApartamentNumber : string.Empty))
            .ForMember(x => x.PostalCode, c => c.MapFrom(s => s.Address != null ? s.Address.PostalCode : string.Empty))
            .ForMember(x => x.City, c => c.MapFrom(s => s.Address != null ? s.Address.City : string.Empty));
    }
}