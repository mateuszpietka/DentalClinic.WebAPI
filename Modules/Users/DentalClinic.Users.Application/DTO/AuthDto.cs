namespace DentalClinic.Users.Application.DTO;

public record AuthDto
(
    string Token,
    string Issuer,
    DateTime ValidFrom,
    DateTime ValidTo
);