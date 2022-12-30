using DentalClinic.MedicalRecords.Core.PatientCards.Entities;
using DentalClinic.MedicalRecords.Core.PatientCards.Exceptions;
using DentalClinic.MedicalRecords.Core.PatientCards.Repositories;
using DentalClinic.Users.Shared.Events;
using MediatR;

namespace DentalClinic.MedicalRecords.Application.PatientCars.EventsExternal.Handlers;
internal class PatientRegisteredHandler : INotificationHandler<PatientRegistered>
{
    private readonly IPatientCardRepository _patientCardRepository;

    public PatientRegisteredHandler(IPatientCardRepository patientCardRepository)
    {
        _patientCardRepository = patientCardRepository;
    }

    public async Task Handle(PatientRegistered notification, CancellationToken cancellationToken)
    {
        if ((await _patientCardRepository.GetAllAsync(x => x.PatientId == notification.PatientId)).Any())
            throw new PatientCardExistsException();

        var patientCard = new PatientCard()
        {
            PatientId = notification.PatientId
        };

        await _patientCardRepository.AddAsync(patientCard);
    }
}