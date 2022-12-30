using DentalClinic.Users.Core.Entities;
using DentalClinic.Users.Core.Exceptions;
using DentalClinic.Users.Core.Repositories;
using MediatR;

namespace DentalClinic.Users.Application.Command.Handler;
internal class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly IUserRepository _userRepository;

    public DeleteEmployeeCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.EmployeeId);

        if (user == null || (user.Role.Name != Role.Doctor && user.Role.Name != Role.Receptionist))
            throw new UserNotFoundException();

        await _userRepository.DeleteAsync(user);

        return Unit.Value;
    }

}
