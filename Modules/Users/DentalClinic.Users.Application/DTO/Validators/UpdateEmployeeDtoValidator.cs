using FluentValidation;

namespace DentalClinic.Users.Application.DTO.Validators;
internal class UpdateEmployeeDtoValidator : AbstractValidator<UpdateEmployeeDto>
{
    public UpdateEmployeeDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(50);

        When(customer => !string.IsNullOrEmpty(customer.Password), () =>
        {
            RuleFor(x => x.Password)
                .Length(8, 100)
                .Matches("[A-Z]")
                .Matches("[a-z]")
                .Matches("[0-9]");

            RuleFor(x => x.ConfirmePassword)
                .Equal(e => e.Password);
        });
    }
}
