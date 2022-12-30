using AutoMapper;
using DentalClinic.VisitSchedule.Application.DTO;
using DentalClinic.VisitSchedule.Core.Entities;

namespace DentalClinic.VisitSchedule.Application.MappingProfiles;
internal class VisitMappingProfile : Profile
{
    public VisitMappingProfile()
    {
        CreateMap<CreateFirstVisitDto, Visit>()
            .ForMember(x => x.IsFirstVisit, c => c.MapFrom(s => true));

        CreateMap<CreateVisitDto, Visit>()
            .ForMember(x => x.IsFirstVisit, c => c.MapFrom(s => false));

        CreateMap<Visit, VisitDetailsDto>()
            .ForMember(x => x.VisitType, c => c.MapFrom(s => s.VisitType.Description));
    }
}