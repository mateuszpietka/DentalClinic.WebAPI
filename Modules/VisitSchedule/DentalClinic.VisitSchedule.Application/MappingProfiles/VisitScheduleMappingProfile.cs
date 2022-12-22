using AutoMapper;
using DentalClinic.VisitSchedule.Application.DTO;
using DentalClinic.VisitSchedule.Core.VistSchedule;

namespace DentalClinic.VisitSchedule.Application.MappingProfiles;
internal class VisitScheduleMappingProfile : Profile
{
    public VisitScheduleMappingProfile()
    {
        CreateMap<IEnumerable<IVisitToSchedule>, VisitScheduleDto>()
            .ForMember(x => x.Visits, c => c.MapFrom(s => s.Select(z => new VisitDto()
            {
                Id = z.Id,
                DateFrom = z.DateFrom,
                DateTo = z.DateTo,
                IsFirstVisit = z.IsFirstVisit
            })));
    }
}