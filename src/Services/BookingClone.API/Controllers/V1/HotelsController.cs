using BookingClone.Application.Features.HotelFeatures.AddHotel;
using BookingClone.Application.Features.HotelFeatures.DeleteHotel;
using BookingClone.Application.Features.HotelFeatures.DTOs;
using BookingClone.Application.Features.HotelFeatures.Queries.GetAll;
using BookingClone.Application.Features.HotelFeatures.Queries.GetById;
using BookingClone.Application.Features.HotelFeatures.UpdateHotel;
using BookingClone.Domain.Common;

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingClone.API.Controllers.V1;

[Route("api/[controller]")]
[ApiController]
public class HotelsController : ControllerBase
{
    private readonly IMediator _mediator;

    public HotelsController(IMediator mediator)
        => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetPaginatedHotels([FromQuery] PaginationQuery query, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetAllHotelsQuery() { Query = query }, ct);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetHotelById(int id, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetByIdQuery { ID = id }, ct);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddHotel(AddHotelDto request, CancellationToken ct)
    {
        var result = await _mediator.Send(new AddHotelCommand { Dto = request }, ct);
        return CreatedAtAction(nameof(GetHotelById), new { ID = result.Id }, result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateExistingHotel(UpdateHotelDto request, CancellationToken ct)
    {
        var result = await _mediator.Send(new UpdateHotelCommand { Dto = request }, ct);
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHotelById(int id, CancellationToken ct)
    {
        var result = await _mediator.Send(new DeleteHotelCommand { Id = id }, ct);
        return result <= 0 ? NotFound() : NoContent();
    }
}
