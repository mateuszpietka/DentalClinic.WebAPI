using DentalClinic.MedicalRecords.Application.PatientCards.DTO;
using MediatR;

namespace DentalClinic.MedicalRecords.Application.PatientCards.Queries;
public record GetPatientCardQuery(long patientId) : IRequest<PatientCardDto>;