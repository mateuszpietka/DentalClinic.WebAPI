using AutoMapper;
using DentalClinic.MedicalRecords.Application.PatientCards.Command;
using DentalClinic.MedicalRecords.Core.PatientCards.Entities;
using DentalClinic.MedicalRecords.Core.PatientCards.Exceptions;
using DentalClinic.MedicalRecords.Core.PatientCards.Repositories;
using DentalClinic.Users.Shared;
using MediatR;

namespace DentalClinic.MedicalRecords.Application.PatientCards.Command.Handlers;
internal class AddPatientCardAnnotationCommandHandler : IRequestHandler<AddPatientCardAnnotationCommand>
{
    private readonly IMapper _mapper;
    private readonly IPatientCardRepository _patientCardRepository;
    private readonly IUserModuleApi _userModuleApi;

    public AddPatientCardAnnotationCommandHandler(IMapper mapper, IPatientCardRepository patientCardRepository, IUserModuleApi userModuleApi)
    {
        _mapper = mapper;
        _patientCardRepository = patientCardRepository;
        _userModuleApi = userModuleApi;
    }

    public async Task<Unit> Handle(AddPatientCardAnnotationCommand request, CancellationToken cancellationToken)
    {
        var patientCardAnnotationDto = request.AddPatientCardAnnotationDto;
        await _userModuleApi.GetDoctorAsync(patientCardAnnotationDto.DoctorId);
        await _userModuleApi.GetPatientAsync(patientCardAnnotationDto.PatientId);

        var patientCard = await _patientCardRepository.GetByPatientIdAsync(patientCardAnnotationDto.PatientId);

        if (patientCard == null)
            throw new PatientCardNotExistsExceptions();

        var patientCardAnnotation = _mapper.Map<PatientCardAnnotation>(patientCardAnnotationDto);
        patientCardAnnotation.PatientCardId = patientCard.Id;
        patientCard.PatientCardAnnotations.Add(patientCardAnnotation);
        await _patientCardRepository.UpdateAsync(patientCard);

        return Unit.Value;
    }
}
