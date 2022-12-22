using FluentValidation;

namespace DentalClinic.VisitSchedule.Application.DTO.Validators;
internal class CreateVisitDtoValidator : AbstractValidator<CreateVisitDto>
{
	public CreateVisitDtoValidator()
	{
		RuleFor(x => x.PatientId)
			.NotEmpty()
            .NotNull();

        RuleFor(x => x.DoctorId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.StartDate)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.VisitTypeId)
            .NotEmpty()
            .NotNull();
    }
}
