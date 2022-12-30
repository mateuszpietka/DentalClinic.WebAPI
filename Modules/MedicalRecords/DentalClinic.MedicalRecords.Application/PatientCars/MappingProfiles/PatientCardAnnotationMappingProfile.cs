using AutoMapper;
using DentalClinic.MedicalRecords.Application.PatientCars.DTO;
using DentalClinic.MedicalRecords.Core.PatientCards.Entities;

namespace DentalClinic.MedicalRecords.Application.PatientCars.MappingProfiles;
internal class PatientCardAnnotationMappingProfile : Profile
{
    public PatientCardAnnotationMappingProfile()
    {
        CreateMap<AddPatientCardAnnotationDto, PatientCardAnnotation>()
            .ForMember(x => x.CreationDate, z => z.MapFrom(y => DateTime.UtcNow));
    }
}
