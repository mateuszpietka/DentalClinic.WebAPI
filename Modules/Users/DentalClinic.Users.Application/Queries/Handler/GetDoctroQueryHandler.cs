using AutoMapper;
using DentalClinic.Users.Core.Exceptions;
using DentalClinic.Users.Core.Repositories;
using DentalClinic.Users.Shared.DTO;
using MediatR;

namespace DentalClinic.Users.Application.Queries.Handler;

internal class GetDoctroQueryHandler : IRequestHandler<GetDoctorQuery, DoctorDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetDoctroQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<DoctorDto> Handle(GetDoctorQuery request, CancellationToken cancellationToken)
    {
        var doctor = await _userRepository.GetByIdAsync(request.DoctorId);

        if (doctor == null || doctor.Role.Name != "Doctor")
            throw new UserNotFoundException();

        var doctorDto = _mapper.Map<DoctorDto>(doctor);

        return doctorDto;
    }
}
