﻿using DentalClinic.Users.Shared.DTO;
using MediatR;

namespace DentalClinic.Users.Application.Queries;

public record GetPatientsQuery() : IRequest<IEnumerable<PatientDto>>;
