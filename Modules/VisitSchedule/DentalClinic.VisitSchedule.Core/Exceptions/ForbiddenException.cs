using DentalClinic.Shared.Abstarctions.Exceptions;
using System.Net;

namespace DentalClinic.VisitSchedule.Core.Exceptions;
public class ForbiddenException : CustomException
{
    public ForbiddenException()
        :base("My Forbidden excpetion")
    {
            
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.Forbidden;
}
