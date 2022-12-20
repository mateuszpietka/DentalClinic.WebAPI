using AutoMapper;
using DentalClinic.Users.Application.DTO;
using DentalClinic.Users.Core.Repositories;
using MediatR;

namespace DentalClinic.Users.Application.Queries.Handler;

internal class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<EmployeeDto>>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetEmployeesQueryHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await _userRepository.GetAllAsync(x => x.Role.Name == "Doctor" || x.Role.Name == "Receptionist");
        var employeeDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

        return employeeDtos;
    }
}
