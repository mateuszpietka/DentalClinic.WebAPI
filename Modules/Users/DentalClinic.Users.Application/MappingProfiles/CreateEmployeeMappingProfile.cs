using AutoMapper;
using DentalClinic.Users.Application.DTO;
using DentalClinic.Users.Core.Entities;

namespace DentalClinic.Users.Application.MappingProfiles;
internal class CreateEmployeeMappingProfile : Profile
{
    public CreateEmployeeMappingProfile()
    {
        CreateMap<CreateEmployeeDto, User>()
            .ForMember(x => x.IsConfirmed, c => c.MapFrom(s => true));
    }
}