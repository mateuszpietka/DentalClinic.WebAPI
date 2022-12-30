using DentalClinic.MedicalRecords.Application.Toothing.Enums;

namespace DentalClinic.MedicalRecords.Application.Toothing.DTO;
public class ToothDto
{
    public QuadrantType QuadrantCode { get; set; }
    public int ToothNumber { get; set; }
}
