using AutoMapper;
using DentalClinic.MedicalRecords.Application.Toothing.DTO;
using DentalClinic.MedicalRecords.Core.Toothing.Entities;

namespace DentalClinic.MedicalRecords.Application.Toothing.MappingProfiles;
internal class PatientToothMappingProfile : Profile
{
    public PatientToothMappingProfile()
    {
        CreateMap<ToothDto, PatientTooth>()
            .ForMember(x => x.QuadrantCode, z => z.MapFrom(y => y.QuadrantCode));
    }
}
