using DentalClinic.MedicalRecords.Application.PatientCards.DTO;
using MediatR;

namespace DentalClinic.MedicalRecords.Application.PatientCards.Command;
public record AddPatientCardAnnotationCommand(AddPatientCardAnnotationDto AddPatientCardAnnotationDto) : IRequest;