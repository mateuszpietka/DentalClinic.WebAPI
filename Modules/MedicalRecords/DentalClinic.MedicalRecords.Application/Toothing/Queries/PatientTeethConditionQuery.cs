using DentalClinic.MedicalRecords.Application.Toothing.DTO;
using MediatR;

namespace DentalClinic.MedicalRecords.Application.Toothing.Queries;
public record GetPatientTeethConditionQuery(long PatientId) : IRequest<PatientTeethConditionDto>;
