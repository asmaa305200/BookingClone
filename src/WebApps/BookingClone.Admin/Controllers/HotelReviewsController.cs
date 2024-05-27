using BookingClone.Application.Features.HotelReviewFeatures.Commands.AddHotelReview;
using BookingClone.Application.Features.HotelReviewFeatures.Commands.DeleteHotelReview;
using BookingClone.Application.Features.HotelReviewFeatures.Commands.UpdateHotelReview;
using BookingClone.Application.Features.HotelReviewFeatures.DTOs;
using BookingClone.Application.Features.HotelReviewFeatures.Queries.GetHotelReviewById;
using BookingClone.Application.Features.HotelReviewFeatures.Queries.GetAllHotelReviews;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingClone.Admin.Controllers;

[Authorize]
public sealed class HotelReviewsController : Controller
{
    private readonly IMediator _mediator;

    public HotelReviewsController(IMediator mediator)
        => _mediator = mediator;

    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
    {
        var hotelReview = await _mediator.Send(new GetAllHotelReviewsQuery() { Query = new(pageNumber, pageSize) }, ct);
        return View(hotelReview);
    }

    public async Task<IActionResult> Details(int id, CancellationToken ct)
    {
        var hotelReview = await _mediator.Send(new GetHotelReviewByIdQuery { ID = id }, ct);
        return View(hotelReview);
    }

    public IActionResult Create()
        => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AddHotelReviewDto request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(request);

        var newReview = await _mediator.Send(new AddHotelReviewCommand { Dto = request }, ct);
        return RedirectToAction(nameof(Details), new { id = newReview.ID });
    }

    public async Task<IActionResult> Edit(int id, CancellationToken ct)
    {
        var newReview = await _mediator.Send(new GetHotelReviewByIdQuery { ID = id }, ct);
        return View(newReview);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateHotelReviewDto request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(request);

        await _mediator.Send(new UpdateHotelReviewCommand { Dto = request }, ct);
        return RedirectToAction(nameof(Details), new { id = request.ID });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        await _mediator.Send(new DeleteHotelReviewCommand { ID = id }, ct);
        return RedirectToAction(nameof(Index));
    }
}