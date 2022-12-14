using FluentValidation;

namespace DentalClinic.Users.Application.DTO.Validators;
internal class RegisterPatientDtoValidator : AbstractValidator<RegisterPatientDto>
{
    public RegisterPatientDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(100);

        RuleFor(x => x.Password)
            .Length(8, 100)
            .Matches("[A-Z]")
            .Matches("[a-z]")
            .Matches("[0-9]");

        RuleFor(x => x.ConfirmePassword)
            .Equal(e => e.Password);

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.PersonalIdNumber)
            .NotEmpty()
            .Length(11)
            .Custom((value, context) =>
            {
                if (!long.TryParse(value, out long _))
                {
                    context.AddFailure("PersonalIdNumber", "That personal ID number is taken");
                }
            });

        RuleFor(x => x.Phone)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Street)
            .MaximumLength(100);

        RuleFor(x => x.HouseNumber)
            .MaximumLength(10);

        RuleFor(x => x.ApartamentNumber)
            .MaximumLength(10);

        RuleFor(x => x.PostalCode)
            .MaximumLength(20);

        RuleFor(x => x.City)
            .MaximumLength(100);
    }
}
