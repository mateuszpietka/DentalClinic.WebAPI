using AutoMapper;
using DentalClinic.Users.Shared;
using DentalClinic.VisitSchedule.Application.DTO;
using DentalClinic.VisitSchedule.Core.Exceptions;
using DentalClinic.VisitSchedule.Core.Repositories;
using MediatR;

namespace DentalClinic.VisitSchedule.Application.Queries.Handlers;
internal class GetVisitDetilsQueryHandler : IRequestHandler<GetVisitDetilsQuery, VisitDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IVisitRepository _visitRepository;
    private readonly IUserModuleApi _userModuleApi;

    public GetVisitDetilsQueryHandler(IMapper mapper, IVisitRepository visitRepository, IUserModuleApi userModuleApi)
    {
        _mapper = mapper;
        _visitRepository = visitRepository;
        _userModuleApi = userModuleApi;
    }

    public async Task<VisitDetailsDto> Handle(GetVisitDetilsQuery request, CancellationToken cancellationToken)
    {
        var visit = await _visitRepository.GetByIdAsync(request.VisitId);

        if (visit == null)
            throw new VisitNotFoundException();

        var patient = await _userModuleApi.GetPatientAsync(visit.PatientId);
        var visitDetailsDto = _mapper.Map<VisitDetailsDto>(visit);
        visitDetailsDto.PatientName = $"{patient.FirstName} {patient.LastName}";

        return visitDetailsDto;
    }
}
