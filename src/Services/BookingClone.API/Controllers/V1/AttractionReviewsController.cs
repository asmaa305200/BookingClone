using BookingClone.Application.Features.AttractionReviewFeatures.Commands.AddAttractionReview;
using BookingClone.Application.Features.AttractionReviewFeatures.Commands.DeleteAttractionReview;
using BookingClone.Application.Features.AttractionReviewFeatures.Commands.UpdateAttractionReview;
using BookingClone.Application.Features.AttractionReviewFeatures.DTOs;
using BookingClone.Application.Features.AttractionReviewFeatures.Queries.GetAttractionReviewById;
using BookingClone.Application.Features.AttractionReviewFeatures.Queries.GetAllAttractionReviews;
using BookingClone.Domain.Common;

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingClone.API.Controllers.V1;

[Route("api/[controller]")]
[ApiController]
public class AttractionReviewsController : Controller
{
    private readonly IMediator _mediator;

    public AttractionReviewsController(IMediator mediator)
        => _mediator = mediator;


    [HttpGet]
    public async Task<IActionResult> GetPaginatedReservations([FromQuery] PaginationQuery query, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetAllAttractionReviewsQuery() { Query = query }, ct);
        return Ok(result);
    }


    [HttpGet("{id}", Name = "Get_[controller]")]
    public async Task<IActionResult> GetAttractionReviewById(int id, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetAttractionReviewByIdQuery { ID = id }, ct);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddNewAttractionReview(AddAttractionReviewDto request, CancellationToken ct)
    {
        var result = await _mediator.Send(new AddAttractionReviewCommand { Dto = request }, ct);
        return CreatedAtRoute("Get_AttractionReview", new { id = result.ID }, result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateExistingAttractionReview(UpdateAttractionReviewDto request, CancellationToken ct)
    {
        var result = await _mediator.Send(new UpdateAttractionReviewCommand { Dto = request }, ct);
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAttractionReviewById(int id, CancellationToken ct)
    {
        var result = await _mediator.Send(new DeleteAttractionReviewCommand { ID = id }, ct);
        return result <= 0 ? NotFound() : NoContent();
    }

}

