using AutoMapper;
using DentalClinic.MedicalRecords.Application.Toothing.DTO;
using DentalClinic.MedicalRecords.Core.Toothing.Services;
using MediatR;

namespace DentalClinic.MedicalRecords.Application.Toothing.Queries.Handlers;
internal class PatientTeethConditionQueryHandler : IRequestHandler<PatientTeethConditionQuery, PatientTeethConditionDto>
{
    private readonly IMapper _mapper;
    private readonly IPatientToothService _patientToothService;

    public PatientTeethConditionQueryHandler(IMapper mapper, IPatientToothService patientToothService)
    {
        _mapper = mapper;
        _patientToothService = patientToothService;
    }

    public async Task<PatientTeethConditionDto> Handle(PatientTeethConditionQuery request, CancellationToken cancellationToken)
    {
        var patientSickTeeth = await _patientToothService.GetPatietnSickTeeth(request.PatientId);
        var patientHealthyTeeth = await _patientToothService.GetPatietnHealthyTeeth(request.PatientId);

        var patientSickToothDtos = _mapper.Map<IEnumerable<ToothDto>>(patientSickTeeth).ToArray();
        var patientHealthyToothDtos = _mapper.Map<IEnumerable<ToothDto>>(patientHealthyTeeth).ToArray();

        return new PatientTeethConditionDto(patientHealthyToothDtos, patientSickToothDtos);
    }
}
