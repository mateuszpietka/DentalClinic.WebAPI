using AutoMapper;
using DentalClinic.Users.Shared;
using DentalClinic.VisitSchedule.Core.Entities;
using DentalClinic.VisitSchedule.Core.Exceptions;
using DentalClinic.VisitSchedule.Core.Repositories;
using MediatR;

namespace DentalClinic.VisitSchedule.Application.Command.Handlers;
internal class AddVisitCommandHandler : IRequestHandler<AddVisitCommand, long>
{
    private readonly IMapper _mapper;
    private readonly IVisitRepository _visitRepository;
    private readonly IVisitTypeRepository _visitTypeRepository;
    private readonly IUserModuleApi _userModuleApi;

    public AddVisitCommandHandler(
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

    public async Task<long> Handle(AddVisitCommand request, CancellationToken cancellationToken)
    {
        await _userModuleApi.GetDoctorAsync(request.VisitDto.DoctorId);
        var patient = await _userModuleApi.GetPatientAsync(request.VisitDto.PatientId);

        //jeśli dodaje pacjent to sprawdzić czy VisitId zgadza się z tym w tokenie

        if (!patient.IsConfirmed)
            throw new PatientUnconfirmedException("Only an confirmed patient can add the next visit");

        var visitType = await _visitTypeRepository.GetByIdAsync(request.VisitDto.VisitTypeId);

        if (visitType == null)
            throw new VisitTypeNotFoundException();

        //sprawdzenie czy termin jest wolny czyli sprawdzić czy w tym samym czasie pacjent nie ma wizyty i czy w tym samym czasie lekarz nie ma wizyty

        var visit = _mapper.Map<Visit>(request.VisitDto);
        visit.VisitType = visitType;
        await _visitRepository.AddAsync(visit);

        return visit.Id;
    }
}