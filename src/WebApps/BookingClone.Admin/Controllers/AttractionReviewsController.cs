using BookingClone.Application.Features.AttractionReviewFeatures.Commands.AddAttractionReview;
using BookingClone.Application.Features.AttractionReviewFeatures.Commands.DeleteAttractionReview;
using BookingClone.Application.Features.AttractionReviewFeatures.Commands.UpdateAttractionReview;
using BookingClone.Application.Features.AttractionReviewFeatures.DTOs;
using BookingClone.Application.Features.AttractionReviewFeatures.Queries.GetAttractionReviewById;
using BookingClone.Application.Features.AttractionReviewFeatures.Queries.GetAllAttractionReviews;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingClone.Admin.Controllers;

[Authorize]
public sealed class AttractionReviewsController : Controller
{
    private readonly IMediator _mediator;

    public AttractionReviewsController(IMediator mediator)
        => _mediator = mediator;

    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
    {
        var review = await _mediator.Send(new GetAllAttractionReviewsQuery() { Query = new(pageNumber, pageSize) }, ct);
        return View(review);
    }

    public async Task<IActionResult> Details(int id, CancellationToken ct)
    {
        var review = await _mediator.Send(new GetAttractionReviewByIdQuery { ID = id }, ct);
        return View(review);
    }

    public IActionResult Create()
        => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AddAttractionReviewDto request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(request);

        var newReview = await _mediator.Send(new AddAttractionReviewCommand { Dto = request }, ct);
        return RedirectToAction(nameof(Details), new { id = newReview.ID });
    }

    public async Task<IActionResult> Edit(int id, CancellationToken ct)
    {
        var review = await _mediator.Send(new GetAttractionReviewByIdQuery { ID = id }, ct);
        return View(review);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateAttractionReviewDto request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(request);

        await _mediator.Send(new UpdateAttractionReviewCommand { Dto = request }, ct);
        return RedirectToAction(nameof(Details), new { id = request.ID });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        await _mediator.Send(new DeleteAttractionReviewCommand { ID = id }, ct);
        return RedirectToAction(nameof(Index));
    }
}
