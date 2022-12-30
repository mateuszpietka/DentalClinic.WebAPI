using DentalClinic.MedicalRecords.Application.PatientCars.DTO;
using MediatR;

namespace DentalClinic.MedicalRecords.Application.PatientCars.Command;
public record AddPatientCardAnnotationCommand(AddPatientCardAnnotationDto AddPatientCardAnnotationDto) : IRequest;