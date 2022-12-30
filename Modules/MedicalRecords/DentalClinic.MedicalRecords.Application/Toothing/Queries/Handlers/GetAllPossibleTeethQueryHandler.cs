using DentalClinic.MedicalRecords.Application.Toothing.DTO;
using DentalClinic.MedicalRecords.Application.Toothing.Enums;
using MediatR;

namespace DentalClinic.MedicalRecords.Application.Toothing.Queries.Handlers;
internal class GetAllPossibleTeethQueryHandler : IRequestHandler<GetAllPossibleTeethQuery, IEnumerable<ToothDto>>
{
    public GetAllPossibleTeethQueryHandler()
    {

    }

    public Task<IEnumerable<ToothDto>> Handle(GetAllPossibleTeethQuery request, CancellationToken cancellationToken)
    {
        var teeth = new List<ToothDto>();

        foreach (var quadrantType in Enum.GetValues<QuadrantType>())
        {
            if (quadrantType <= QuadrantType.LowerRightPermanent)
            {
                for (int i = 1; i <= 8; i++)
                {
                    teeth.Add(new ToothDto(quadrantType, i));
                }
            }
            else if (quadrantType > QuadrantType.LowerRightPermanent)
            {
                for (int i = 1; i <= 5; i++)
                {
                    teeth.Add(new ToothDto(quadrantType, i));
                }
            }
        }

        return Task.FromResult(teeth.AsEnumerable());
    }
}