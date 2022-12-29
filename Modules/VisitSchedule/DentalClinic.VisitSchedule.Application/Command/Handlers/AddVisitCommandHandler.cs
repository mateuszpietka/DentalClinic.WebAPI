using AutoMapper;
using DentalClinic.Shared.Abstarctions.Services;
using DentalClinic.Users.Shared;
using DentalClinic.VisitSchedule.Core.Entities;
using DentalClinic.VisitSchedule.Core.Exceptions;
using DentalClinic.VisitSchedule.Core.Repositories;
using DentalClinic.VisitSchedule.Core.Services;
using MediatR;

namespace DentalClinic.VisitSchedule.Application.Command.Handlers;
internal class AddVisitCommandHandler : IRequestHandler<AddVisitCommand, long>
{
    private readonly IMapper _mapper;
    private readonly IVisitRepository _visitRepository;
    private readonly IVisitTypeRepository _visitTypeRepository;
    private readonly IUserModuleApi _userModuleApi;
    private readonly IFreeDatesService _freeDatesService;
    private readonly IVisitScheduleService _visitScheduleService;
    private readonly IUserContextService _userContextService;

    public AddVisitCommandHandler(
        IMapper mapper,
        IVisitRepository visitRepository,
        IVisitTypeRepository visitTypeRepository,
        IUserModuleApi userModuleApi,
        IFreeDatesService freeDatesService,
        IVisitScheduleService visitScheduleService,
        IUserContextService userContextService)
    {
        _mapper = mapper;
        _visitRepository = visitRepository;
        _visitTypeRepository = visitTypeRepository;
        _userModuleApi = userModuleApi;
        _freeDatesService = freeDatesService;
        _visitScheduleService = visitScheduleService;
        _userContextService = userContextService;
    }

    public async Task<long> Handle(AddVisitCommand request, CancellationToken cancellationToken)
    {
        var visitDto = request.VisitDto;

        if (_userContextService.RoleName == "Patient" && (_userContextService.UserId == null || _userContextService.UserId != visitDto.PatientId))
            throw new ForbiddenException();

        await _userModuleApi.GetDoctorAsync(request.VisitDto.DoctorId);
        var patient = await _userModuleApi.GetPatientAsync(visitDto.PatientId);

        if (!patient.IsConfirmed)
            throw new PatientUnconfirmedException();

        var visitType = await _visitTypeRepository.GetByIdAsync(visitDto.VisitTypeId);

        if (visitType == null)
            throw new VisitTypeNotFoundException();

        var patientVisits = await _visitScheduleService.GetPatientVisitSchedule(visitDto.PatientId, visitDto.StartDate.AddDays(-1), visitDto.StartDate.AddDays(1));

        if (patientVisits.Any(x => visitDto.StartDate >= x.DateFrom && visitDto.StartDate < x.DateTo))
            throw new FreeDateNotFoundException();

        var freeDates = await _freeDatesService.GetFreeDates(visitDto.DoctorId, visitType, visitDto.StartDate.AddDays(-1), visitDto.StartDate.AddDays(1));

        if (!freeDates.Any(x => x.Equals(visitDto.StartDate)))
            throw new FreeDateNotFoundException();

        var visit = _mapper.Map<Visit>(visitDto);
        visit.VisitType = visitType;
        await _visitRepository.AddAsync(visit);

        return visit.Id;
    }
}