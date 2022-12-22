using FluentValidation;

namespace DentalClinic.VisitSchedule.Application.DTO.Validators;
internal class PatientVisitScheduleFilterDtoValidator : AbstractValidator<PatientVisitScheduleFilterDto>
{
	public PatientVisitScheduleFilterDtoValidator()
	{
		RuleFor(x => x.PatientIds)
			.NotEmpty()
            .NotNull();

        RuleFor(x => x.DateFrom)
            .NotEmpty()
            .NotNull()
            .LessThan(x => x.DateTo);

        RuleFor(x => x.DateTo)
            .NotEmpty()
            .NotNull()
            .GreaterThan(x=>x.DateFrom);
    }
}
