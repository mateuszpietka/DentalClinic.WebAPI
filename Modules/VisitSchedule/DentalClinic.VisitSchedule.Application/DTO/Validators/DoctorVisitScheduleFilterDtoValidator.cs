using DentalClinic.Shared.Abstarctions.Services;
using DentalClinic.VisitSchedule.Core.Exceptions;
using FluentValidation;

namespace DentalClinic.VisitSchedule.Application.DTO.Validators;
internal class DoctorVisitScheduleFilterDtoValidator : AbstractValidator<DoctorVisitScheduleFilterDto>
{
    private readonly IUserContextService _userContextService;

    public DoctorVisitScheduleFilterDtoValidator(IUserContextService userContextService)
    {
        _userContextService = userContextService;

        RuleFor(x => x.DoctorId)
            .NotEmpty()
            .NotNull()
            .Must(x => _userContextService.UserId != null && _userContextService.UserId == x).WithState(x => throw new ForbiddenException());

        RuleFor(x => x.DateFrom)
            .NotEmpty()
            .NotNull()
            .LessThan(x => x.DateTo)
            .Must(x => x.Minute == 0 && x.Second == 0 && x.Millisecond == 0);

        RuleFor(x => x.DateTo)
            .NotEmpty()
            .NotNull()
            .GreaterThan(x => x.DateFrom)
            .Must(x => x.Minute == 0 && x.Second == 0 && x.Millisecond == 0);
    }
}
