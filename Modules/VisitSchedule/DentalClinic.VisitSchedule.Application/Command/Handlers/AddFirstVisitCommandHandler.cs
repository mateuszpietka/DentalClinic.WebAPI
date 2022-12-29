using AutoMapper;
using DentalClinic.Users.Shared;
using DentalClinic.VisitSchedule.Core.Entities;
using DentalClinic.VisitSchedule.Core.Exceptions;
using DentalClinic.VisitSchedule.Core.Repositories;
using DentalClinic.VisitSchedule.Core.Services;
using MediatR;

namespace DentalClinic.VisitSchedule.Application.Command.Handlers;
internal class AddFirstVisitCommandHandler : IRequestHandler<AddFirstVisitCommand, long>
{
    private readonly IMapper _mapper;
    private readonly IVisitRepository _visitRepository;
    private readonly IVisitTypeRepository _visitTypeRepository;
    private readonly IUserModuleApi _userModuleApi;
    private readonly IFreeDatesService _freeDatesService;

    public AddFirstVisitCommandHandler(
        IMapper mapper,
        IVisitRepository visitRepository,
        IVisitTypeRepository visitTypeRepository,
        IUserModuleApi userModuleApi,
        IFreeDatesService freeDatesService)
    {
        _mapper = mapper;
        _visitRepository = visitRepository;
        _visitTypeRepository = visitTypeRepository;
        _userModuleApi = userModuleApi;
        _freeDatesService = freeDatesService;
    }

    public async Task<long> Handle(AddFirstVisitCommand request, CancellationToken cancellationToken)
    {
        var firstVisitDto = request.FirstVisitDto;
        await _userModuleApi.GetDoctorAsync(firstVisitDto.DoctorId);
        var patient = await _userModuleApi.GetPatientAsync(firstVisitDto.PatientId);

        if (patient.IsConfirmed)
            throw new PatientConfirmedException("Only an unconfirmed patient can add the first visit");

        if ((await _visitRepository.GetAllAsync(x => x.PatientId == patient.Id && x.IsFirstVisit == true)).Any())
            throw new FirsVistiAlreadyExistsException();

        var visitType = await _visitTypeRepository.GetByIdAsync(firstVisitDto.VisitTypeId);

        if (visitType == null)
            throw new VisitTypeNotFoundException();

        var freeDates = await _freeDatesService.GetFreeDates(firstVisitDto.DoctorId, visitType, firstVisitDto.StartDate.AddDays(-1), firstVisitDto.StartDate.AddDays(1));

        if (!freeDates.Any(x => x.Equals(firstVisitDto.StartDate)))
            throw new FreeDateNotFoundException();

        var visit = _mapper.Map<Visit>(firstVisitDto);
        visit.VisitType = visitType;
        await _visitRepository.AddAsync(visit);

        return visit.Id;
    }
}