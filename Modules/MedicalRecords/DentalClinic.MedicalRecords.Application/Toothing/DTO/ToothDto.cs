using DentalClinic.MedicalRecords.Application.Toothing.Enums;

namespace DentalClinic.MedicalRecords.Application.Toothing.DTO;
public class ToothDto
{
    public ToothDto()
    {

    }

    public ToothDto(QuadrantType quadrantType, int toothNumber)
    {
        QuadrantCode = quadrantType;
        ToothNumber = toothNumber;
    }

    public QuadrantType QuadrantCode { get; set; }
    public int ToothNumber { get; set; }
}
