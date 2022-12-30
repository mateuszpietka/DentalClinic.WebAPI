using AutoMapper;
using DentalClinic.Users.Core.Entities;
using DentalClinic.Users.Core.Repositories;
using DentalClinic.Users.Shared.DTO;
using MediatR;

namespace DentalClinic.Users.Application.Queries.Handler;

internal class GetPatientsQueryHandler : IRequestHandler<GetPatientsQuery, IEnumerable<PatientDto>>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetPatientsQueryHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<PatientDto>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
    {
        var patients = await _userRepository.GetAllAsync(x => x.Role.Name == Role.Patient);
        var patientDtos = _mapper.Map<IEnumerable<PatientDto>>(patients);

        return patientDtos;
    }
}
