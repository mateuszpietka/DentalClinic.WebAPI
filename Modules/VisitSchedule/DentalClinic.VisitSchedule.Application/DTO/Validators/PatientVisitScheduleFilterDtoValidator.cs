using DentalClinic.Shared.Abstarctions.Services;
using DentalClinic.VisitSchedule.Core.Exceptions;
using FluentValidation;

namespace DentalClinic.VisitSchedule.Application.DTO.Validators;
internal class PatientVisitScheduleFilterDtoValidator : AbstractValidator<PatientVisitScheduleFilterDto>
{
    private readonly IUserContextService _userContextService;

    public PatientVisitScheduleFilterDtoValidator(IUserContextService userContextService)
	{
        _userContextService = userContextService;

        RuleFor(x => x.PatientId)
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
            .GreaterThan(x=>x.DateFrom)
            .Must(x => x.Minute == 0 && x.Second == 0 && x.Millisecond == 0)
            .Custom((valueToValidate, context) =>
            {
                var dateRange = valueToValidate - context.InstanceToValidate.DateFrom;

                if (dateRange > TimeSpan.FromDays(7))
                    context.AddFailure("DateTo", "The date range is greater than 7 days");
            });;
    }
}
