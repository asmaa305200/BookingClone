using BookingClone.Application.Features.AttractionFeatures.Commands.AddAttraction;
using BookingClone.Application.Features.AttractionFeatures.Commands.DeleteAttraction;
using BookingClone.Application.Features.AttractionFeatures.Commands.UpdateAttraction;
using BookingClone.Application.Features.AttractionFeatures.DTOs;
using BookingClone.Application.Features.AttractionFeatures.Queries.GetAttractionById;
using BookingClone.Application.Features.AttractionFeatures.Queries.GetPaginatedAttractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingClone.Admin.Controllers;

[Authorize]
public sealed class AttractionsController : Controller
{
    private readonly IMediator _mediator;

    public AttractionsController(IMediator mediator)
        => _mediator = mediator;

    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
    {
        var attractions = await _mediator.Send(new GetPaginatedAttractionsQuery() { Query = new(pageNumber, pageSize) }, ct);
        return View(attractions);
    }

    public async Task<IActionResult> Details(int id, CancellationToken ct)
    {
        var attraction = await _mediator.Send(new GetAttractionByIdQuery { ID = id }, ct);
        return View(attraction);
    }

    public IActionResult Create()
        => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AddAttractionDto request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(request);

        var newAttraction = await _mediator.Send(new AddAttractionCommand { Dto = request }, ct);
        return RedirectToAction(nameof(Details), new { id = newAttraction.ID });
    }

    public async Task<IActionResult> Edit(int id, CancellationToken ct)
    {
        var attraction = await _mediator.Send(new GetAttractionByIdQuery { ID = id }, ct);
        return View(attraction);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateAttractionDto request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(request);

        await _mediator.Send(new UpdateAttractionCommand { Dto = request }, ct);
        return RedirectToAction(nameof(Details), new { id = request.ID });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        await _mediator.Send(new DeleteAttractionCommand { ID = id }, ct);
        return RedirectToAction(nameof(Index));
    }
}
