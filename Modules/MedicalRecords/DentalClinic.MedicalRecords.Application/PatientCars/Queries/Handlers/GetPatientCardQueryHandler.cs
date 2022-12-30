using DentalClinic.MedicalRecords.Application.PatientCars.DTO;
using DentalClinic.MedicalRecords.Core.PatientCards.Repositories;
using DentalClinic.Users.Shared;
using MediatR;

namespace DentalClinic.MedicalRecords.Application.PatientCars.Queries.Handlers;
internal class GetPatientCardQueryHandler : IRequestHandler<GetPatientCardQuery, PatientCardDto>
{
    private readonly IPatientCardRepository _patientCardRepository;
    private readonly IUserModuleApi _userModuleApi;

    public GetPatientCardQueryHandler(IPatientCardRepository patientCardRepository, IUserModuleApi userModuleApi)
    {
        _patientCardRepository = patientCardRepository;
        _userModuleApi = userModuleApi;
    }

    async Task<PatientCardDto> IRequestHandler<GetPatientCardQuery, PatientCardDto>.Handle(GetPatientCardQuery request, CancellationToken cancellationToken)
    {
        var patient = await _userModuleApi.GetPatientAsync(request.patientId);
        var patientCard = await _patientCardRepository.GetByPatientIdAsync(request.patientId);
        var patientsCardAnnotationDtos = new List<PatientCardAnnotationDto>();
        var patientCardDto = new PatientCardDto()
        {
            Id = patientCard.Id,
            PatientFullName = $"{patient.FirstName} {patient.LastName}"
        };

        foreach (var patianetCardAnnotation in patientCard.PatientCardAnnotations)
        {
            var doctor = await _userModuleApi.GetDoctorAsync(patianetCardAnnotation.DoctorId);
            var patientCardAnnotationDto = new PatientCardAnnotationDto()
            {
                Id = patianetCardAnnotation.Id,
                DoctorFullName = $"{doctor.FirstName} {doctor.LastName}",
                CreationDate = patianetCardAnnotation.CreationDate,
                Contents = patianetCardAnnotation.Contents
            };

            patientsCardAnnotationDtos.Add(patientCardAnnotationDto);
        }

        patientCardDto.PatientCardAnnotations = patientsCardAnnotationDtos.ToArray();

        return patientCardDto;
    }
}