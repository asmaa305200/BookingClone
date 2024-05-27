using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace BookingClone.Admin.Controllers;
public class RoomController : Controller
{

    private readonly IMediator _mediator;

    public RoomController(IMediator mediator)
        => _mediator = mediator;

    //public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
    //{
    //    var reservations = await _mediator.Send(new GetAllRoomReservationsQuery() { Query = new(pageNumber, pageSize) }, ct);
    //    return View(reservations);
    //}
}
