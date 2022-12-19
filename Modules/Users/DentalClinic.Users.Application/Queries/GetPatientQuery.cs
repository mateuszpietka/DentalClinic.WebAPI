using DentalClinic.Users.Application.DTO;
using MediatR;

namespace DentalClinic.Users.Application.Queries;

public record GetPatientQuery(long PatientId) : IRequest<PatientDetailsDto>;
