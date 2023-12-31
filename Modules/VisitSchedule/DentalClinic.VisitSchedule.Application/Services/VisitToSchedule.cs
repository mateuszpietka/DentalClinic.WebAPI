﻿using DentalClinic.VisitSchedule.Core.VistSchedule;

namespace DentalClinic.VisitSchedule.Application.Services;
internal class VisitToSchedule : IVisitToSchedule
{
    public VisitToSchedule(long id, DateTime dateFrom, DateTime dateTo, bool isFirstVisit)
    {
        Id = id;
        DateFrom = dateFrom;
        DateTo = dateTo;
        IsFirstVisit = isFirstVisit;
    }

    public long Id { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public bool IsFirstVisit { get; set; }

    public override bool Equals(object obj)
    {
        return obj is VisitToSchedule other
            && Id == other.Id
            && DateFrom == other.DateFrom
            && DateTo == other.DateTo
            && IsFirstVisit == other.IsFirstVisit;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
