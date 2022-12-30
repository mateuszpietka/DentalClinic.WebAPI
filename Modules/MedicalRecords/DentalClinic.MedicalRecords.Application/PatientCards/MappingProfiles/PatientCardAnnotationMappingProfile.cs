using AutoMapper;
using DentalClinic.MedicalRecords.Application.PatientCards.DTO;
using DentalClinic.MedicalRecords.Core.PatientCards.Entities;

namespace DentalClinic.MedicalRecords.Application.PatientCards.MappingProfiles;
internal class PatientCardAnnotationMappingProfile : Profile
{
    public PatientCardAnnotationMappingProfile()
    {
        CreateMap<AddPatientCardAnnotationDto, PatientCardAnnotation>()
            .ForMember(x => x.CreationDate, z => z.MapFrom(y => DateTime.UtcNow));
    }
}
