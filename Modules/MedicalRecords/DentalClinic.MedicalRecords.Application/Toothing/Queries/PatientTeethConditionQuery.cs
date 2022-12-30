using DentalClinic.MedicalRecords.Application.Toothing.DTO;
using MediatR;

namespace DentalClinic.MedicalRecords.Application.Toothing.Queries;
public record PatientTeethConditionQuery(long PatientId) : IRequest<PatientTeethConditionDto>;
