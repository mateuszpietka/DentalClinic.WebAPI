using AutoMapper;
using DentalClinic.Users.Shared;
using DentalClinic.VisitSchedule.Core.Entities;
using DentalClinic.VisitSchedule.Core.Exceptions;
using DentalClinic.VisitSchedule.Core.Repositories;
using MediatR;

namespace DentalClinic.VisitSchedule.Application.Command.Handlers;
internal class AddFirstVisitCommandHandler : IRequestHandler<AddFirstVisitCommand, int>
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

    public async Task<int> Handle(AddFirstVisitCommand request, CancellationToken cancellationToken)
    {
        await _userModuleApi.GetDoctorAsync(request.FirstVisitDto.DoctorId);
        await _userModuleApi.GetPatientAsync(request.FirstVisitDto.PatientId);
        var visitType = _visitTypeRepository.GetByIdAsync(request.FirstVisitDto.VisitTypeId);

        if (visitType == null)
            throw new VisitTypeNotFoundException();

        //sprawdzenie terminu

        var visit = _mapper.Map<Visit>(request.FirstVisitDto);
        await _visitRepository.AddAsync(visit);

        return visitType.Id;
    }
}