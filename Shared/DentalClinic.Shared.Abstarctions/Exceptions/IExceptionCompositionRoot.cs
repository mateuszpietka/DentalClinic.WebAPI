using System;

namespace DentalClinic.Shared.Abstarctions.Exceptions;

public interface IExceptionCompositionRoot
{
    IExceptionResponse Map(Exception exception);
}