using AutoMapper;
using BookingClone.Application.Features.HotelFeatures.DTOs;
using BookingClone.Domain.Common;
using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.HotelFeatures.Queries.GetAll;

public class GetAllQueryHandler : IRequestHandler<GetAllHotelsQuery, PagedList<GetHotelsDto>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public GetAllQueryHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task<PagedList<GetHotelsDto>> Handle(GetAllHotelsQuery request, CancellationToken cancellationToken)
    {
        var hotel = await _hotelRepository.GetPaginatedList(request.Query, cancellationToken);
        return _mapper.Map<PagedList<GetHotelsDto>>(hotel);
    }
}
