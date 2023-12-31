﻿using AutoMapper;
using DentalClinic.Users.Core.Entities;
using DentalClinic.Users.Core.Exceptions;
using DentalClinic.Users.Core.Repositories;
using DentalClinic.Users.Shared.Events;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DentalClinic.Users.Application.Command.Handler;

internal class RegisterPatientCommandHandler : IRequestHandler<RegisterPatientCommand, long>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public RegisterPatientCommandHandler(
        IMapper mapper, 
        IUserRepository userRepository, 
        IRoleRepository roleRepository, 
        IPasswordHasher<User> passwordHasher, 
        IMediator mediator)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _passwordHasher = passwordHasher;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<long> Handle(RegisterPatientCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.AnyAsync(x => x.Email == request.RegisterPatientDto.Email))
            throw new PropertyExistsException("email");

        if (await _userRepository.AnyAsync(x => x.PersonalIdNumber == request.RegisterPatientDto.PersonalIdNumber))
            throw new PropertyExistsException("personal ID number");

        var role = await _roleRepository.GetByNameAsync(Role.Patient);
        var user = _mapper.Map<User>(request.RegisterPatientDto);
        user.Role = role;
        user.RoleId = role.Id;
        user.PasswordHash = _passwordHasher.HashPassword(user, request.RegisterPatientDto.Password);
        await _userRepository.AddAsync(user);
        await _mediator.Publish(new PatientRegistered(user.Id));

        return user.Id;
    }
}
