using BookingClone.Application.Features.continent.commands.AddContinent;
using BookingClone.Application.Features.continent.commands.DeleteContinent;
using BookingClone.Application.Features.continent.commands.UpdateContinent;
using BookingClone.Application.Features.continent.DTOs;
using BookingClone.Application.Features.continent.queries.GetAllcontinent;
using BookingClone.Application.Features.continent.queries.GetContinentById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingClone.Admin.Controllers;

[Authorize]
public sealed class ContinentController : Controller
{

    private readonly IMediator _mediator;

    public ContinentController(IMediator mediator)
        => _mediator = mediator;

    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
    {
        var reservations = await _mediator.Send(new getallcontinentquery2() { Query = new(pageNumber, pageSize) }, ct);
        return View(reservations);
    }

    public async Task<IActionResult> Details(int id, CancellationToken ct)
    {
        var reservation = await _mediator.Send(new GetContinentByIdQuery(id), ct);
        return View(reservation);
    }

    public IActionResult Create()
        => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ContinentDetailsDto request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(request);

        var newReservation = await _mediator.Send(new addcontinentcommand2 { Dto = request }, ct);
        return RedirectToAction(nameof(Details), new { id = newReservation.ID });
    }





    public async Task<IActionResult> Edit(int id, CancellationToken ct)
    {
        var reservations = await _mediator.Send(new GetContinentByIdQuery(id), ct);
        return View(reservations);
    }




    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ContinentDetailsDto request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(request);

        await _mediator.Send(new updatecontinentcommand2 { Dto = request }, ct);
        return RedirectToAction(nameof(Details), new { id = request.ID });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        await _mediator.Send(new DeleteContinentCommmand(id), ct);
        return RedirectToAction(nameof(Index));
    }




}
