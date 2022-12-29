namespace DentalClinic.VisitSchedule.Core.VistSchedule;

public interface IVisitToSchedule
{
    long Id { get; set; }
    DateTime DateFrom { get; set; }
    DateTime DateTo { get; set; }
    bool IsFirstVisit { get; set; }
}