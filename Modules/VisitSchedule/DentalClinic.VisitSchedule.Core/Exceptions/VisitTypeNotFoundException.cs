using DentalClinic.Shared.Abstarctions.Exceptions;
using System.Net;

namespace DentalClinic.VisitSchedule.Core.Exceptions;
public class VisitTypeNotFoundException : CustomException
{
    public VisitTypeNotFoundException() 
        : base("Visit type not found")
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}
