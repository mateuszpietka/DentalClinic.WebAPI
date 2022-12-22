using DentalClinic.VisitSchedule.Core.Exceptions;
using DentalClinic.VisitSchedule.Core.Repositories;
using MediatR;

namespace DentalClinic.VisitSchedule.Application.Command.Handlers;
internal class CancellationVisitCommandHandler : IRequestHandler<CancellationVisitCommand>
{
    private readonly IVisitRepository _visitRepository;

    public CancellationVisitCommandHandler(IVisitRepository visitRepository)
    {
        _visitRepository = visitRepository;
    }

    public async Task<Unit> Handle(CancellationVisitCommand request, CancellationToken cancellationToken)
    {
        var visit = await _visitRepository.GetByIdAsync(request.VisitId);

        if (visit == null)
            throw new VisitNotFoundException();

        await _visitRepository.DeleteAsync(visit);

        return Unit.Value;
    }
}