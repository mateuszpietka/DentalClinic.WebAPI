using AutoMapper;
using DentalClinic.Users.Application.DTO;
using DentalClinic.Users.Core.Entities;
using DentalClinic.Users.Core.Exceptions;
using DentalClinic.Users.Core.Repositories;
using MediatR;

namespace DentalClinic.Users.Application.Queries.Handler;
internal class GetPatientQueryHandler : IRequestHandler<GetPatientQuery, PatientDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetPatientQueryHandler(IMapper mapper, IUserRepository userRepository)
	{
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<PatientDetailsDto> Handle(GetPatientQuery request, CancellationToken cancellationToken)
    {
        var patient = await _userRepository.GetByIdAsync(request.PatientId);

        if (patient == null || patient.Role.Name != Role.Patient)
            throw new UserNotFoundException();

        var patientDetailsDto = _mapper.Map<PatientDetailsDto>(patient);

        return patientDetailsDto;
    }
}
