using DentalClinic.Users.Core.Exceptions;
using DentalClinic.Users.Core.Repositories;
using MediatR;

namespace DentalClinic.Users.Application.Command.Handler;
internal class ConfirmPatientCommandHandler : IRequestHandler<ConfirmPatientCommand>
{
    private readonly IUserRepository _userRepository;

    public ConfirmPatientCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(ConfirmPatientCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.PatientId);

        if (user == null)
            throw new UserNotFoundException();

        user.IsConfirmed = true;
        await _userRepository.UpdateAsync(user);

        return Unit.Value;
    }

}
