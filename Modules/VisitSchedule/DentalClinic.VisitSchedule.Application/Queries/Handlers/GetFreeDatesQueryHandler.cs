using AutoMapper;
using DentalClinic.Users.Shared;
using DentalClinic.VisitSchedule.Application.DTO;
using DentalClinic.VisitSchedule.Core.Exceptions;
using DentalClinic.VisitSchedule.Core.Repositories;
using DentalClinic.VisitSchedule.Core.Services;
using MediatR;

namespace DentalClinic.VisitSchedule.Application.Queries.Handlers;
internal class GetFreeDatesQueryHandler : IRequestHandler<GetFreeDatesQuery, FreeDatesDto>
{
    private readonly IMapper _mapper;
    private readonly IFreeDatesServices _freeDatesServices;
    private readonly IUserModuleApi _userModuleApi;
    private readonly IVisitTypeRepository _visitTypeRepository;

    public GetFreeDatesQueryHandler(IMapper mapper, IFreeDatesServices freeDatesServices, IUserModuleApi userModuleApi, IVisitTypeRepository visitTypeRepository)
    {
        _mapper = mapper;
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
