using DentalClinic.MedicalRecords.Application.Toothing.DTO;
using MediatR;

namespace DentalClinic.MedicalRecords.Application.Toothing.Command;
public record MarkHealthyTeethCommand(MarkTeethDto MarkTeethDto) : IRequest;
