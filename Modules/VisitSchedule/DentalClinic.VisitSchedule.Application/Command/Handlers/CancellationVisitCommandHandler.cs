using DentalClinic.Shared.Abstarctions.Services;
using DentalClinic.VisitSchedule.Core.Exceptions;
using DentalClinic.VisitSchedule.Core.Repositories;
using MediatR;

namespace DentalClinic.VisitSchedule.Application.Command.Handlers;
internal class CancellationVisitCommandHandler : IRequestHandler<CancellationVisitCommand>
{
    private readonly IVisitRepository _visitRepository;
    private readonly IUserContextService _userContextService;

    public CancellationVisitCommandHandler(IVisitRepository visitRepository, IUserContextService userContextService)
    {
        _visitRepository = visitRepository;
        _userContextService = userContextService;
    }

    public async Task<Unit> Handle(CancellationVisitCommand request, CancellationToken cancellationToken)
    {
        var visit = await _visitRepository.GetByIdAsync(request.VisitId);

        if (visit == null)
            throw new VisitNotFoundException();

        if (_userContextService.RoleName == "Patient" && (_userContextService.UserId == null || _userContextService.UserId != visit.PatientId))
            throw new ForbiddenException();

        await _visitRepository.DeleteAsync(visit);

        return Unit.Value;
    }
}