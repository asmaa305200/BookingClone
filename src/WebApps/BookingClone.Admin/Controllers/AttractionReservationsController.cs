using BookingClone.Application.Features.AttractionReservationFeatures.Commands.AddAttractionReservation;
using BookingClone.Application.Features.AttractionReservationFeatures.Commands.DeleteAttractionReservation;
using BookingClone.Application.Features.AttractionReservationFeatures.Commands.UpdateAttractionReservation;
using BookingClone.Application.Features.AttractionReservationFeatures.DTOs;
using BookingClone.Application.Features.AttractionReservationFeatures.Queries.GetAttractionReservationById;
using BookingClone.Application.Features.RoomReservationFeatures.Queries.GetAllRoomReservations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingClone.Admin.Controllers;

[Authorize]
public sealed class AttractionReservationsController : Controller
{
    private readonly IMediator _mediator;

    public AttractionReservationsController(IMediator mediator)
        => _mediator = mediator;

    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
    {
        var reservations = await _mediator.Send(new GetAllAttractionReservationsQuery() { Query = new(pageNumber, pageSize) }, ct);
        return View(reservations);
    }

    public async Task<IActionResult> Details(int id, CancellationToken ct)
    {
        var reservation = await _mediator.Send(new GetAttractionReservationByIdQuery { ID = id }, ct);
        return View(reservation);
    }

    public IActionResult Create()
        => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AddAttractionReservationDto request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(request);

        var newReservation = await _mediator.Send(new AddAttractionReservationCommand { Dto = request }, ct);
        return RedirectToAction(nameof(Details), new { id = newReservation.ID });
    }

    public async Task<IActionResult> Edit(int id, CancellationToken ct)
    {
        var reservations = await _mediator.Send(new GetAttractionReservationByIdQuery { ID = id }, ct);
        return View(reservations);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateAttractionReservationDto request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(request);

        await _mediator.Send(new UpdateAttractionReservationCommand { Dto = request }, ct);
        return RedirectToAction(nameof(Details), new { id = request.ID });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        await _mediator.Send(new DeleteAttractionReservationCommand { ID = id }, ct);
        return RedirectToAction(nameof(Index));
    }
}
