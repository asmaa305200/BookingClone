using BookingClone.Application.Features.AttractionReservationFeatures.Commands.AddAttractionReservation;
using BookingClone.Application.Features.AttractionReservationFeatures.Commands.DeleteAttractionReservation;
using BookingClone.Application.Features.AttractionReservationFeatures.Commands.UpdateAttractionReservation;
using BookingClone.Application.Features.AttractionReservationFeatures.DTOs;
using BookingClone.Application.Features.AttractionReservationFeatures.Queries.GetAttractionReservationById;
using BookingClone.Application.Features.AttractionReservationFeatures.Queries.GetReservedAttractionDetails;
using BookingClone.Application.Features.AttractionReservationFeatures.Queries.GetReservedAttractionDetailsById;
using BookingClone.Application.Features.RoomReservationFeatures.Queries.GetAllRoomReservations;
using BookingClone.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingClone.API.Controllers.V1;

[Route("api/[controller]")]
[ApiController]
public class AttractionReservationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AttractionReservationsController(IMediator mediator)
        => _mediator = mediator;

    /// <summary>
    /// Gets Attraction Reservation in pages
    /// </summary>
    /// <param name="query">Pagination Query</param>
    /// <param name="ct"></param>
    /// <returns>A page of Attraction Reservations</returns>
    [HttpGet]
    public async Task<IActionResult> GetPaginatedReservations([FromQuery] PaginationQuery query, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetAllAttractionReservationsQuery() { Query = query }, ct);
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
        var result = await _mediator.Send(new GetAttractionReservationByIdQuery { ID = id }, ct);
        return result is null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Adds a new Reservation
    /// </summary>
    /// <param name="request">The request Body containing new data</param>
    /// <param name="ct"></param>
    /// <returns>The newly added entity with ID generated</returns>
    [HttpPost]
    public async Task<IActionResult> AddNewReservation(AddAttractionReservationDto request, CancellationToken ct)
    {
        var result = await _mediator.Send(new AddAttractionReservationCommand { Dto = request }, ct);
        return CreatedAtRoute("Get_AttractionReservations", new { id = result.ID }, result);
    }

    /// <summary>
    /// Updates an existing Reservation
    /// </summary>
    /// <param name="request">The request Body containing updated data</param>
    /// <param name="ct"></param>
    /// <returns>The existing entity with updated Data</returns>
    [HttpPut]
    public async Task<IActionResult> UpdateExistingReservation(UpdateAttractionReservationDto request, CancellationToken ct)
    {
        var result = await _mediator.Send(new UpdateAttractionReservationCommand { Dto = request }, ct);
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
        var result = await _mediator.Send(new DeleteAttractionReservationCommand { ID = id }, ct);
        return result <= 0 ? NotFound() : NoContent();
    }

    /// <summary>
    /// Gets all ReservedRooms for a single Reservation
    /// </summary>
    /// <param name="reservationId"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpGet("{reservationId}/Reservations")]
    public async Task<IActionResult> GetReservedAttractionDetails(int reservationId, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetAllReservedAttractionDetailsQuery { ReservationId = reservationId }, ct);
        return Ok(result);
    }

    /// <summary>
    /// Get a single ReservedRoom for a single Reservation
    /// </summary>
    /// <param name="reservationId"></param>
    /// <param name="attractionId"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpGet("{reservationId}/Reservations/{attractionId}")]
    public async Task<IActionResult> GetReservedAttractionDetailsById(int reservationId, int attractionId, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetReservedAttractionDetailsByIdQuery(reservationId, attractionId), ct);
        return Ok(result);
    }
}
