using DentalClinic.Users.Shared.DTO;
using MediatR;

namespace DentalClinic.Users.Application.Queries;

internal record GetDoctorQuery(long DoctorId): IRequest<DoctorDto>;
