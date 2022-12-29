using FluentValidation;

namespace DentalClinic.VisitSchedule.Application.DTO.Validators;
internal class PatientVisitScheduleFilterDtoValidator : AbstractValidator<PatientVisitScheduleFilterDto>
{
	public PatientVisitScheduleFilterDtoValidator()
	{
		RuleFor(x => x.PatientId)
			.NotEmpty()
            .NotNull();

        RuleFor(x => x.DateFrom)
            .NotEmpty()
            .NotNull()
            .LessThan(x => x.DateTo)
            .Must(x => x.Minute == 0 && x.Second == 0 && x.Millisecond == 0);

        RuleFor(x => x.DateTo)
            .NotEmpty()
            .NotNull()
            .GreaterThan(x=>x.DateFrom)
            .Must(x => x.Minute == 0 && x.Second == 0 && x.Millisecond == 0);
    }
}
