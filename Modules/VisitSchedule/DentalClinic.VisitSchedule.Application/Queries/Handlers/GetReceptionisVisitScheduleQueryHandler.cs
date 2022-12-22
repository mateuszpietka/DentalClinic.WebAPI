using AutoMapper;
using DentalClinic.Users.Shared;
using DentalClinic.VisitSchedule.Application.DTO;
using DentalClinic.VisitSchedule.Core.Services;
using MediatR;

namespace DentalClinic.VisitSchedule.Application.Queries.Handlers;

internal class GetReceptionisVisitScheduleQueryHandler : IRequestHandler<GetReceptionistVisitScheduleQuery, VisitScheduleDto>
{
    private readonly IUserModuleApi _userModuleApi;
    private readonly IVisitScheduleService _visitScheduleService;
    private readonly IMapper _mapper;

    public GetReceptionisVisitScheduleQueryHandler(IUserModuleApi userModuleApi, IVisitScheduleService visitScheduleService, IMapper mapper)
    {
        _userModuleApi = userModuleApi;
        _visitScheduleService = visitScheduleService;
        _mapper = mapper;
    }

    public async Task<VisitScheduleDto> Handle(GetReceptionistVisitScheduleQuery request, CancellationToken cancellationToken)
    {
        var visitScheduleFilter = request.VisitScheduleFilter;
        await _userModuleApi.GetDoctorAsync(visitScheduleFilter.DoctorId);

        foreach (var patientId in visitScheduleFilter.PatientIds)
            await _userModuleApi.GetPatientAsync(patientId);

        var visitsToSchedule = await _visitScheduleService.GetReceptionistVisitSchedule(visitScheduleFilter.DoctorId, visitScheduleFilter.PatientIds, visitScheduleFilter.DateFrom, visitScheduleFilter.DateTo);
        var visitSchedule = _mapper.Map<VisitScheduleDto>(visitsToSchedule);

        return visitSchedule;
    }
}
