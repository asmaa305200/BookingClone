using BookingClone.Application.Features.HotelFeatures.AddHotel;
using BookingClone.Application.Features.HotelFeatures.DeleteHotel;
using BookingClone.Application.Features.HotelFeatures.DTOs;
using BookingClone.Application.Features.HotelFeatures.Queries.GetAll;
using BookingClone.Application.Features.HotelFeatures.Queries.GetById;
using BookingClone.Application.Features.HotelFeatures.UpdateHotel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace BookingClone.Admin.Controllers;

[Authorize]
public sealed class HotelsController : Controller
{
    private readonly IMediator _mediator;

    public HotelsController(IMediator mediator)
       => _mediator = mediator;

    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
    {
        var hotel = await _mediator.Send(new GetAllHotelsQuery() { Query = new(pageNumber, pageSize) }, ct);
        return View(hotel);
    }

    public async Task<IActionResult> Details(int id, CancellationToken ct)
    {
        var hotel = await _mediator.Send(new GetByIdQuery { ID = id }, ct);
        return View(hotel);
    }

    public IActionResult Create()
        => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AddHotelDto request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(request);

        var newHotel = await _mediator.Send(new AddHotelCommand { Dto = request }, ct);
        return RedirectToAction(nameof(Details), new { id = newHotel.Id });
    }

    public async Task<IActionResult> Edit(int id, CancellationToken ct)
    {
        var hotel = await _mediator.Send(new GetByIdQuery { ID = id }, ct);
        return View(hotel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateHotelDto request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(request);

        await _mediator.Send(new UpdateHotelCommand { Dto = request }, ct);
        return RedirectToAction(nameof(Details), new { id = request.Id });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        await _mediator.Send(new DeleteHotelCommand { Id = id }, ct);
        return RedirectToAction(nameof(Index));
    }
}
