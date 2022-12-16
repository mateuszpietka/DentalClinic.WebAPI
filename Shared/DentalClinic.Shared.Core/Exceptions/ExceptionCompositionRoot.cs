using DentalClinic.Shared.Abstarctions.Exceptions;

namespace DentalClinic.Shared.Core.Exceptions;

internal sealed class ExceptionCompositionRoot : IExceptionCompositionRoot
{
    private readonly IEnumerable<IExceptionToResponseMapper> _mappers;

    public ExceptionCompositionRoot(IEnumerable<IExceptionToResponseMapper> mappers)
    {
        _mappers = mappers;
    }

    public IExceptionResponse Map(Exception exception)
    {
        var nonDefaultMappers = _mappers.Where(x => x is not DefaultExceptionToResponseMapper);
        var result = nonDefaultMappers
            .Select(x => x.Map(exception))
            .SingleOrDefault(x => x is not null);

        if (result is not null)
            return result;

        var defaultMapper = _mappers.SingleOrDefault(x => x is DefaultExceptionToResponseMapper);

        return defaultMapper?.Map(exception);
    }
}