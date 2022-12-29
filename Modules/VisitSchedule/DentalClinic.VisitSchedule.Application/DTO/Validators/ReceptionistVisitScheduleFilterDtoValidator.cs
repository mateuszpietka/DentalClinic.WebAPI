using FluentValidation;

namespace DentalClinic.VisitSchedule.Application.DTO.Validators;
internal class ReceptionistVisitScheduleFilterDtoValidator : AbstractValidator<ReceptionistVisitScheduleFilterDto>
{
	public ReceptionistVisitScheduleFilterDtoValidator()
	{
		RuleFor(x => x.DoctorId)
			.NotEmpty()
            .NotNull();

        RuleFor(x => x.PatientIds)
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
            .Must(x => x.Minute == 0 && x.Second == 0 && x.Millisecond == 0)
            .Custom((valueToValidate, context) =>
            {
                var dateRange = valueToValidate - context.InstanceToValidate.DateFrom;

                if (dateRange > TimeSpan.FromDays(7))
                    context.AddFailure("DateTo", "The date range is greater than 7 days");
            });
    }
}
