using DentalClinic.Users.Core.Entities;
using DentalClinic.Users.Core.Exceptions;
using DentalClinic.Users.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DentalClinic.Users.Application.Command.Handler;
internal class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UpdateEmployeeCommandHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var userToUpdate = await _userRepository.GetByIdAsync(request.UpdateEmployeeDto.EmployeeId);

        if (userToUpdate == null || (userToUpdate.Role.Name != "Doctor" && userToUpdate.Role.Name != "Receptionist"))
            throw new UserNotFoundException();

        userToUpdate.FirstName = request.UpdateEmployeeDto.FirstName;
        userToUpdate.LastName = request.UpdateEmployeeDto.LastName;

        if (!string.IsNullOrEmpty(request.UpdateEmployeeDto.Password))
            userToUpdate.PasswordHash = _passwordHasher.HashPassword(userToUpdate, request.UpdateEmployeeDto.Password);

        await _userRepository.UpdateAsync(userToUpdate);

        return Unit.Value;
    }
}
