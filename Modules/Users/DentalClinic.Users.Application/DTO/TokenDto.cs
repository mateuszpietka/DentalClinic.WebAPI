namespace DentalClinic.Users.Application.DTO;

public record TokenDto
(
    string Token,
    DateTime ValidTo
);