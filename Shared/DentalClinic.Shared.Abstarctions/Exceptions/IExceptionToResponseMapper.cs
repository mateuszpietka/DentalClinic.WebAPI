namespace DentalClinic.Shared.Abstarctions.Exceptions;

public interface IExceptionToResponseMapper
{
    IExceptionResponse Map(Exception exception);
}