using BookingClone.Application.Features.RoomReservationFeatures.Commands.AddRoomReservation;
using BookingClone.Application.Features.RoomReservationFeatures.Commands.DeleteRoomReservation;
using BookingClone.Application.Features.RoomReservationFeatures.Commands.UpdateRoomReservation;
using BookingClone.Application.Features.RoomReservationFeatures.DTOs;
using BookingClone.Application.Features.RoomReservationFeatures.Queries.GetAllRoomReservations;
using BookingClone.Application.Features.RoomReservationFeatures.Queries.GetRoomReservationById;
using BookingClone.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingClone.API.Controllers.V1;

[Route("api/[controller]")]
[ApiController]
public class RoomReservationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoomReservationsController(IMediator mediator)
        => _mediator = mediator;

    /// <summary>
    /// Gets Room Reservation in pages
    /// </summary>
    /// <param name="query">Pagination Query</param>
    /// <param name="ct"></param>
    /// <returns>A page of Room Reservations</returns>
    [HttpGet]
    public async Task<IActionResult> GetPaginatedReservations([FromQuery] PaginationQuery query, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetAllRoomReservationsQuery() { Query = query }, ct);
        return Ok(result);
    }

    /// <summary>
    /// Gets a single Reservation by ID
    /// </summary>
    /// <param name="id">The unique Identifier of Reservation</param>
    /// <param name="ct"></param>
    /// <returns>Reservation with specified ID</returns>
    [HttpGet("{id}", Name = "Get_[controller]")]
    public async Task<IActionResult> GetReservationById(int id, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetRoomReservationByIdQuery { ID = id }, ct);
        return result is null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Adds a new Reservation
    /// </summary>
    /// <param name="request">The request Body containing new data</param>
    /// <param name="ct"></param>
    /// <returns>The newly added entity with ID generated</returns>
    [HttpPost]
    public async Task<IActionResult> AddNewReservation(AddRoomReservationDto request, CancellationToken ct)
    {
        var result = await _mediator.Send(new AddRoomReservationCommand { Dto = request }, ct);
        return CreatedAtRoute("Get_RoomReservations", new { id = result.ID }, result);
    }

    /// <summary>
    /// Updates an existing Reservation
    /// </summary>
    /// <param name="request">The request Body containing updated data</param>
    /// <param name="ct"></param>
    /// <returns>The existing entity with updated Data</returns>
    [HttpPut]
    public async Task<IActionResult> UpdateExistingReservation(UpdateRoomReservationDto request, CancellationToken ct)
    {
        var result = await _mediator.Send(new UpdateRoomReservationCommand { Dto = request }, ct);

        return result is not null ? Ok(result) : NotFound();
    }

    /// <summary>
    /// Deletes an existing reservation
    /// </summary>
    /// <param name="id">The unique Identifier of Reservation</param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReservationById(int id, CancellationToken ct)
    {
        var result = await _mediator.Send(new DeleteRoomReservationCommand { ID = id }, ct);
        return result <= 0 ? NotFound() : NoContent();
    }
}
