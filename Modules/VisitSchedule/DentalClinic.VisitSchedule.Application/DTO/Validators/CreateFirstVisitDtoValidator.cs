using FluentValidation;

namespace DentalClinic.VisitSchedule.Application.DTO.Validators;
internal class CreateFirstVisitDtoValidator : AbstractValidator<CreateFirstVisitDto>
{
	public CreateFirstVisitDtoValidator()
	{
		RuleFor(x => x.PatientId)
			.NotEmpty()
            .NotNull();

        RuleFor(x => x.DoctorId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.StartDate)
            .NotEmpty()
            .NotNull()
            .Must(x => x.Minute == 0 && x.Second == 0 && x.Millisecond == 0);

        RuleFor(x => x.VisitTypeId)
            .NotEmpty()
            .NotNull();
    }
}
