using AutoMapper;
using DentalClinic.Users.Shared;
using DentalClinic.VisitSchedule.Core.Entities;
using DentalClinic.VisitSchedule.Core.Exceptions;
using DentalClinic.VisitSchedule.Core.Repositories;
using MediatR;

namespace DentalClinic.VisitSchedule.Application.Command.Handlers;
internal class AddFirstVisitCommandHandler : IRequestHandler<AddFirstVisitCommand, long>
{
    private readonly IMapper _mapper;
    private readonly IVisitRepository _visitRepository;
    private readonly IVisitTypeRepository _visitTypeRepository;
    private readonly IUserModuleApi _userModuleApi;

    public AddFirstVisitCommandHandler(
        IMapper mapper,
        IVisitRepository visitRepository,
        IVisitTypeRepository visitTypeRepository,
        IUserModuleApi userModuleApi)
    {
        _mapper = mapper;
        _visitRepository = visitRepository;
        _visitTypeRepository = visitTypeRepository;
        _userModuleApi = userModuleApi;
    }

    public async Task<long> Handle(AddFirstVisitCommand request, CancellationToken cancellationToken)
    {
        await _userModuleApi.GetDoctorAsync(request.FirstVisitDto.DoctorId);
        var patient = await _userModuleApi.GetPatientAsync(request.FirstVisitDto.PatientId);

        if (patient.IsConfirmed)
            throw new PatientConfirmedException("Only an unconfirmed patient can add the first visit");

        if ((await _visitRepository.GetAllAsync(x => x.PatientId == patient.Id && x.IsFirstVisit == true)).Any())
            throw new FirsVistiAlreadyExistsException();

        var visitType = await _visitTypeRepository.GetByIdAsync(request.FirstVisitDto.VisitTypeId);

        if (visitType == null)
            throw new VisitTypeNotFoundException();

        var visit = _mapper.Map<Visit>(request.FirstVisitDto);
        visit.VisitType = visitType;
        await _visitRepository.AddAsync(visit);

        return visit.Id;
    }
}