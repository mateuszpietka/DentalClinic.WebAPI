using DentalClinic.Users.Shared;
using DentalClinic.VisitSchedule.Application.DTO;
using DentalClinic.VisitSchedule.Core.Exceptions;
using DentalClinic.VisitSchedule.Core.Repositories;
using DentalClinic.VisitSchedule.Core.Services;
using MediatR;

namespace DentalClinic.VisitSchedule.Application.Queries.Handlers;
internal class GetFreeDatesQueryHandler : IRequestHandler<GetFreeDatesQuery, FreeDatesDto>
{
    private readonly IFreeDatesService _freeDatesServices;
    private readonly IUserModuleApi _userModuleApi;
    private readonly IVisitTypeRepository _visitTypeRepository;

    public GetFreeDatesQueryHandler(IFreeDatesService freeDatesServices, IUserModuleApi userModuleApi, IVisitTypeRepository visitTypeRepository)
    {
        _freeDatesServices = freeDatesServices;
        _userModuleApi = userModuleApi;
        _visitTypeRepository = visitTypeRepository;
    }

    public async Task<FreeDatesDto> Handle(GetFreeDatesQuery request, CancellationToken cancellationToken)
    {
        var freeDatesFilter = request.FreeDatesFilter;
        await _userModuleApi.GetDoctorAsync(freeDatesFilter.DoctorId);
        var visitType = await _visitTypeRepository.GetByIdAsync(freeDatesFilter.VisitTypeId);

        if (visitType == null)
            throw new VisitTypeNotFoundException();

        var freeDates = await _freeDatesServices.GetFreeDates(freeDatesFilter.DoctorId, visitType, freeDatesFilter.DateFrom, freeDatesFilter.DateTo);

        return new FreeDatesDto(freeDates.ToArray());
    }
}