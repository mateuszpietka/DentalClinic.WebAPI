using AutoMapper;
using DentalClinic.Users.Application.DTO;
using DentalClinic.Users.Core.Entities;

namespace DentalClinic.Users.Application.MappingProfiles;
internal class RegisterPatientMappingProfile : Profile
{
    public RegisterPatientMappingProfile()
    {
        CreateMap<RegisterPatientDto, User>()
            .ForMember(x => x.IsConfirmed, c => c.MapFrom(s => false))
            .ForMember(x => x.Address, c => c.MapFrom(s => string.IsNullOrEmpty(s.Street) ?
                                                           null :
                                                           new Address()
                                                           {
                                                               Street = s.Street,
                                                               HouseNumber = s.HouseNumber,
                                                               ApartamentNumber = s.ApartamentNumber,
                                                               PostalCode = s.PostalCode,
                                                               City = s.City,
                                                           }));
    }
}