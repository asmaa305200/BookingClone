using BookingClone.Application.Features.RoomFeatures.Commands.AddRoom;
using BookingClone.Application.Features.RoomFeatures.Commands.DeleteRoom;
using BookingClone.Application.Features.RoomFeatures.Commands.UpdateRoom;
using BookingClone.Application.Features.RoomFeatures.DTOs;
using BookingClone.Application.Features.RoomFeatures.Queries.GetAllRooms;
using BookingClone.Application.Features.RoomFeatures.Queries.GetRoomById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingClone.Admin.Controllers;

[Authorize]
public sealed class RoomsController : Controller
{
    private readonly IMediator _mediator;

    public RoomsController(IMediator mediator)
        => _mediator = mediator;

    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
    {
        var room = await _mediator.Send(new GetAllRoomsQuery() { Query = new(pageNumber, pageSize) }, ct);
        return View(room);
    }

    public async Task<IActionResult> Details(int id, CancellationToken ct)
    {
        var room = await _mediator.Send(new GetRoomByIdQuery { ID = id }, ct);
        return View(room);
    }

    public IActionResult Create()
        => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AddRoomDto request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(request);

        var newRoom = await _mediator.Send(new AddRoomCommand { Dto = request }, ct);
        return RedirectToAction(nameof(Details), new { id = newRoom.ID });
    }

    public async Task<IActionResult> Edit(int id, CancellationToken ct)
    {
        var room = await _mediator.Send(new GetRoomByIdQuery { ID = id }, ct);
        return View(room);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateRoomDto request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(request);

        await _mediator.Send(new UpdateRoomCommand { Dto = request }, ct);
        return RedirectToAction(nameof(Details), new { id = request.ID });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        await _mediator.Send(new DeleteRoomCommand { ID = id }, ct);
        return RedirectToAction(nameof(Index));
    }
}
