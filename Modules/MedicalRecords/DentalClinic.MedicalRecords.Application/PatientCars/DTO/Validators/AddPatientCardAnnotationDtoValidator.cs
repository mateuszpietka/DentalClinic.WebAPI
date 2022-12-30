using FluentValidation;

namespace DentalClinic.MedicalRecords.Application.PatientCars.DTO.Validators;
internal class AddPatientCardAnnotationDtoValidator : AbstractValidator<AddPatientCardAnnotationDto>
{
    public AddPatientCardAnnotationDtoValidator()
    {
        RuleFor(x=>x.PatientId)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.DoctorId)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Contents)
            .NotNull()
            .MaximumLength(1000);
    }
}
