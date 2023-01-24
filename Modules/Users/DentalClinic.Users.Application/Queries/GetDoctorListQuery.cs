using DentalClinic.Users.Shared.DTO;
using MediatR;

namespace DentalClinic.Users.Application.Queries;
public record GetDoctorsQuery(): IRequest<IEnumerable<DoctorDto>>;
