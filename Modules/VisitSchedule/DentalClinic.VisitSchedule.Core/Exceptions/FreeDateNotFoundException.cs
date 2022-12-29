using DentalClinic.Shared.Abstarctions.Exceptions;
using System.Net;

namespace DentalClinic.VisitSchedule.Core.Exceptions;
public class FreeDateNotFoundException : CustomException
{
    public FreeDateNotFoundException()
        : base("The selected meeting time is already taken or is invalid")
    {

    }

    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}