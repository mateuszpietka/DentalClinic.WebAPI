using AutoMapper;
using DentalClinic.MedicalRecords.Application.Toothing.DTO;
using DentalClinic.MedicalRecords.Application.Toothing.Enums;
using DentalClinic.MedicalRecords.Core.Toothing.Entities;

namespace DentalClinic.MedicalRecords.Application.Toothing.MappingProfiles;
internal class PatientToothMappingProfile : Profile
{
    public PatientToothMappingProfile()
    {
        CreateMap<ToothDto, PatientTooth>()
            .ForMember(x => x.QuadrantCode, z => z.MapFrom(y => y.QuadrantCode));

        CreateMap<PatientTooth, ToothDto>()
            .ForMember(x => x.QuadrantCode, z => z.MapFrom(y => (QuadrantType)y.QuadrantCode));
    }
}
