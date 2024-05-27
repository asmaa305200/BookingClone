using BookingClone.Application.Features.RoomReservationFeatures.Commands.AddRoomReservation;
using BookingClone.Application.Features.RoomReservationFeatures.Commands.DeleteRoomReservation;
using BookingClone.Application.Features.RoomReservationFeatures.Commands.UpdateRoomReservation;
using BookingClone.Application.Features.RoomReservationFeatures.DTOs;
using BookingClone.Application.Features.RoomReservationFeatures.Queries.GetAllRoomReservations;
using BookingClone.Application.Features.RoomReservationFeatures.Queries.GetRoomReservationById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingClone.Admin.Controllers;

[Authorize]
public sealed class RoomReservationsController : Controller
{
    private readonly IMediator _mediator;

    public RoomReservationsController(IMediator mediator)
        => _mediator = mediator;

    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
    {
        var reservations = await _mediator.Send(new GetAllRoomReservationsQuery() { Query = new(pageNumber, pageSize) }, ct);
        return View(reservations);
    }

    public async Task<IActionResult> Details(int id, CancellationToken ct)
    {
        var reservation = await _mediator.Send(new GetRoomReservationByIdQuery { ID = id }, ct);
        return View(reservation);
    }

    public IActionResult Create()
        => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AddRoomReservationDto request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(request);

        var newReservation = await _mediator.Send(new AddRoomReservationCommand { Dto = request }, ct);
        return RedirectToAction(nameof(Details), new { id = newReservation.ID });
    }

    public async Task<IActionResult> Edit(int id, CancellationToken ct)
    {
        var reservations = await _mediator.Send(new GetRoomReservationByIdQuery { ID = id }, ct);
        return View(reservations);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateRoomReservationDto request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(request);

        await _mediator.Send(new UpdateRoomReservationCommand { Dto = request }, ct);
        return RedirectToAction(nameof(Details), new { id = request.ID });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        await _mediator.Send(new DeleteRoomReservationCommand { ID = id }, ct);
        return RedirectToAction(nameof(Index));
    }
}
