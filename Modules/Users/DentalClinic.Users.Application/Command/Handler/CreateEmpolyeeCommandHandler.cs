using AutoMapper;
using DentalClinic.Users.Core.Entities;
using DentalClinic.Users.Core.Exceptions;
using DentalClinic.Users.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DentalClinic.Users.Application.Command.Handler;
internal class CreateEmpolyeeCommandHandler : IRequestHandler<CreateEmpolyeeCommand, long>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IMapper _mapper;

    public CreateEmpolyeeCommandHandler(
        IMapper mapper,
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _passwordHasher = passwordHasher;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateEmpolyeeCommand request, CancellationToken cancellationToken)
    {
        var createEmployeeDto = request.CreateEmployeeDto;

        if (await _userRepository.AnyAsync(x => x.Email == createEmployeeDto.Email))
            throw new PropertyExistsException("email");

        var role = await _roleRepository.GetByNameAsync(createEmployeeDto.RoleName);

        if (role == null || (role.Name != "Doctor" && role.Name == "Receptionist"))
            throw new IncorrectRoleException();

        var user = _mapper.Map<User>(createEmployeeDto);
        user.Role = role;
        user.RoleId = role.Id;
        user.PasswordHash = _passwordHasher.HashPassword(user, createEmployeeDto.Password);
        await _userRepository.AddAsync(user);

        return user.Id;
    }
}
