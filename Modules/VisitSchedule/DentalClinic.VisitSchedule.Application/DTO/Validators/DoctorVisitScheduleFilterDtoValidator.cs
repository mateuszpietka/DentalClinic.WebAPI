using FluentValidation;

namespace DentalClinic.VisitSchedule.Application.DTO.Validators;
internal class DoctorVisitScheduleFilterDtoValidator : AbstractValidator<DoctorVisitScheduleFilterDto>
{
	public DoctorVisitScheduleFilterDtoValidator()
	{
		RuleFor(x => x.DoctorId)
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
