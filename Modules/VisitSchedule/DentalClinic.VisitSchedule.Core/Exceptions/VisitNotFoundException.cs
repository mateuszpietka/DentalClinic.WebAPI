using DentalClinic.Shared.Abstarctions.Exceptions;
using System.Net;

namespace DentalClinic.VisitSchedule.Core.Exceptions;

public class VisitNotFoundException : CustomException
{
    public VisitNotFoundException() : base("Visit not found")
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}
