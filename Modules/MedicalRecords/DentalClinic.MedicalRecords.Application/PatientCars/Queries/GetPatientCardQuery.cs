using DentalClinic.MedicalRecords.Application.PatientCars.DTO;
using MediatR;

namespace DentalClinic.MedicalRecords.Application.PatientCars.Queries;
public record GetPatientCardQuery(long patientId): IRequest<PatientCardDto>;