using AutoMapper;
using DentalClinic.MedicalRecords.Application.Toothing.Enums;
using DentalClinic.MedicalRecords.Core.Toothing.Entities;
using DentalClinic.MedicalRecords.Core.Toothing.Services;
using DentalClinic.Users.Shared;
using MediatR;

namespace DentalClinic.MedicalRecords.Application.Toothing.Command.Handlers;
internal class MarkSickTeethCommandHandler : IRequestHandler<MarkSickTeethCommand>
{
    private readonly IMapper _mapper;
    private readonly IPatientToothService _patientToothService;
    private readonly IUserModuleApi _userModuleApi;

    public MarkSickTeethCommandHandler(IMapper mapper, IPatientToothService patientToothService, IUserModuleApi userModuleApi)
    {
        _mapper = mapper;
        _patientToothService = patientToothService;
        _userModuleApi = userModuleApi;
    }

    public async Task<Unit> Handle(MarkSickTeethCommand request, CancellationToken cancellationToken)
    {
        var patient = await _userModuleApi.GetPatientAsync(request.MarkTeethDto.PatientId);
        var patientTeeth = _mapper.Map<IEnumerable<PatientTooth>>(request.MarkTeethDto.Teeth);

        foreach (var patientTooth in patientTeeth)
        {
            patientTooth.PatientId = patient.Id;
            patientTooth.Condition = (int)ConditionType.Sick;
        }

        await _patientToothService.UpdatePatientTeethAsync(patientTeeth);

        return Unit.Value;
    }
}
