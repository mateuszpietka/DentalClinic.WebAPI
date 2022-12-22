using AutoMapper;
using DentalClinic.Users.Shared;
using DentalClinic.VisitSchedule.Application.DTO;
using DentalClinic.VisitSchedule.Core.Services;
using MediatR;

namespace DentalClinic.VisitSchedule.Application.Queries.Handlers;

internal class GetPatientVisitScheduleQueryHandler : IRequestHandler<GetPatientVisitScheduleQuery, VisitScheduleDto>
{
    private readonly IUserModuleApi _userModuleApi;
    private readonly IVisitScheduleService _visitScheduleService;
    private readonly IMapper _mapper;

    public GetPatientVisitScheduleQueryHandler(IUserModuleApi userModuleApi, IVisitScheduleService visitScheduleService, IMapper mapper)
    {
        _userModuleApi = userModuleApi;
        _visitScheduleService = visitScheduleService;
        _mapper = mapper;
    }

    public async Task<VisitScheduleDto> Handle(GetPatientVisitScheduleQuery request, CancellationToken cancellationToken)
    {
        var visitScheduleFilter = request.VisitScheduleFilter;
        await _userModuleApi.GetPatientAsync(visitScheduleFilter.PatientId);
        //czy patientId jest tym samym co w tokenie

        var visitsToSchedule = await _visitScheduleService.GetPatientVisitSchedule(visitScheduleFilter.PatientId, visitScheduleFilter.DateFrom, visitScheduleFilter.DateTo);
        var visitSchedule = _mapper.Map<VisitScheduleDto>(visitsToSchedule);

        return visitSchedule;
    }
}
