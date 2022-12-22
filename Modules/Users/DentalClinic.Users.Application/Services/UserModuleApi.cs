using AutoMapper;
using DentalClinic.Users.Application.Queries;
using DentalClinic.Users.Shared;
using DentalClinic.Users.Shared.DTO;
using MediatR;

namespace DentalClinic.Users.Application.Services;
internal class UserModuleApi : IUserModuleApi
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UserModuleApi(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<DoctorDto> GetDoctorAsync(long id)
    {
        return await _mediator.Send(new GetDoctorQuery(id));
    }

    public async Task<PatientDto> GetPatientAsync(long id)
    {
        var patientDetails = await _mediator.Send(new GetPatientQuery(id));

        return _mapper.Map<PatientDto>(patientDetails);
    }
}
