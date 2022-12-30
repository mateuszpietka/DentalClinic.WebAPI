using FluentValidation;

namespace DentalClinic.MedicalRecords.Application.Toothing.DTO.Validators;
internal class MarkTeethDtoValidator : AbstractValidator<MarkTeethDto>
{
    public MarkTeethDtoValidator(IValidator<ToothDto> validator)
    {
        RuleFor(x => x.PatientId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Teeth)
            .NotNull();

        RuleForEach(x => x.Teeth)
            .SetValidator(validator);
    }
}
