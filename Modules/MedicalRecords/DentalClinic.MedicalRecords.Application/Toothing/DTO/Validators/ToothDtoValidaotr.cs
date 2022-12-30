using DentalClinic.MedicalRecords.Application.Toothing.Enums;
using FluentValidation;

namespace DentalClinic.MedicalRecords.Application.Toothing.DTO.Validators;
internal class ToothDtoValidaotr : AbstractValidator<ToothDto>
{
    public ToothDtoValidaotr()
    {
        RuleFor(x => x.QuadrantCode)
            .IsInEnum();

        RuleFor(x => x.ToothNumber)
            .Custom((valueToValidate, context) =>
            {
                if (context.InstanceToValidate.QuadrantCode >= QuadrantType.UpperRightDeciduous
                && (valueToValidate < 1 || valueToValidate > 5))
                {
                    context.AddFailure("If the teeth are deciduous, the number should be between 1 and 5");
                }

                if (context.InstanceToValidate.QuadrantCode <= QuadrantType.LowerRightPermanent
                    && (valueToValidate < 1 || valueToValidate > 8))
                {
                    context.AddFailure("If the teeth are permanent, the number should be between 1 and 8");
                }
            });
    }
}