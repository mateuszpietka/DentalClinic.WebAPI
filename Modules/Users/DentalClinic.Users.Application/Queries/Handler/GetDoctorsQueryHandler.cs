using AutoMapper;
using DentalClinic.Users.Core.Entities;
using DentalClinic.Users.Core.Repositories;
using DentalClinic.Users.Shared.DTO;
using MediatR;

namespace DentalClinic.Users.Application.Queries.Handler;

internal class GetDoctorsQueryHandler : IRequestHandler<GetDoctorsQuery, IEnumerable<DoctorDto>>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetDoctorsQueryHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<DoctorDto>> Handle(GetDoctorsQuery request, CancellationToken cancellationToken)
    {
        var doctors = await _userRepository.GetAllAsync(x => x.Role.Name == Role.Doctor);
        var doctorDtos = _mapper.Map<IEnumerable<DoctorDto>>(doctors);

        return doctorDtos;
    }
}
