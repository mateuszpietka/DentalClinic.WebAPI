using DentalClinic.Users.Application.Queries;
using DentalClinic.Users.Shared;
using DentalClinic.Users.Shared.DTO;
using MediatR;

namespace DentalClinic.Users.Application.Services;
internal class UserModuleApi : IUserModuleApi
{
    private readonly IMediator _mediator;

    public UserModuleApi(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<DoctorDto> GetDoctorAsync(long id)
    {
        return await _mediator.Send(new GetDoctorQuery(id));
    }

    public async Task<PatientDto> GetPatientAsync(long id)
    {
        var patientDetails = await _mediator.Send(new GetPatientQuery(id));

        return new PatientDto()
        {
            Id = id,
            FirstName = patientDetails.FirstName,
            LastName = patientDetails.LastName,
            PersonalIdNumber = patientDetails.PersonalIdNumber,
            Email = patientDetails.Email,
        };
    }
}
