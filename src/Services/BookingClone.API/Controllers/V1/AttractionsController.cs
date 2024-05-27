using BookingClone.Application.Features.AttractionFeatures.Commands.AddAttraction;
using BookingClone.Application.Features.AttractionFeatures.Commands.AddAttractionImage;
using BookingClone.Application.Features.AttractionFeatures.Commands.DeleteAttraction;
using BookingClone.Application.Features.AttractionFeatures.Commands.UpdateAttraction;
using BookingClone.Application.Features.AttractionFeatures.DTOs;
using BookingClone.Application.Features.AttractionFeatures.Queries.GetAttractionById;
using BookingClone.Application.Features.AttractionFeatures.Queries.GetPaginatedAttractions;
using BookingClone.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingClone.API.Controllers.V1;

[Route("api/[controller]")]
[ApiController]
public class AttractionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AttractionsController(IMediator mediator)
        => _mediator = mediator;

    /// <summary>
    /// Get Attractions in pages
    /// </summary>
    /// <param name="query"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetPaginatedAttractions([FromQuery] PaginationQuery query, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetPaginatedAttractionsQuery { Query = query }, ct);
        return Ok(result);
    }

    /// <summary>
    /// Gets a single Attraction by ID
    /// </summary>
    /// <param name="id">The unique Identifier of Attraction</param>
    /// <param name="ct"></param>
    /// <returns>Attraction with specified ID</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAttractionById(int id, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetAttractionByIdQuery { ID = id }, ct);
        return result is null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Adds a new Attraction
    /// </summary>
    /// <param name="request">The request Body containing new data</param>
    /// <param name="ct"></param>
    /// <returns>The newly added entity with ID generated</returns>
    [HttpPost]
    public async Task<IActionResult> AddNewAttraction(AddAttractionDto request, CancellationToken ct)
    {
        var result = await _mediator.Send(new AddAttractionCommand { Dto = request }, ct);
        return CreatedAtAction(nameof(GetAttractionById), new { id = result.ID }, result);
    }

    /// <summary>
    /// Adds images to an Attraction
    /// </summary>
    /// <param name="id">The unique Identifier of Attraction</param>
    /// <param name="images">THe images from request Body</param>
    /// <param name="ct"></param>
    /// <returns>The Generated URLs for images</returns>
    [HttpPost("{id}/images")]
    public async Task<IActionResult> AddAttractionImages(int id, [FromForm] List<IFormFile> images, CancellationToken ct)
    {
        if (!images.Any())
            return BadRequest("No images were found in Form Body");

        var result = await _mediator.Send(new AddAttractionImageCommand() { ID = id, Images = images }, ct);
        return result is null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Updates an existing Attraction
    /// </summary>
    /// <param name="request">The request Body containing updated data</param>
    /// <param name="ct"></param>
    /// <returns>The existing entity with updated Data</returns>
    [HttpPut]
    public async Task<IActionResult> UpdateExistingAttraction(UpdateAttractionDto request, CancellationToken ct)
    {
        var result = await _mediator.Send(new UpdateAttractionCommand { Dto = request }, ct);
        return result is not null ? Ok(result) : NotFound();
    }

    /// <summary>
    /// Deletes an existing Attraction
    /// </summary>
    /// <param name="id">The unique Identifier of Attraction</param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAttractionById(int id, CancellationToken ct)
    {
        var result = await _mediator.Send(new DeleteAttractionCommand { ID = id }, ct);
        return result <= 0 ? NotFound() : NoContent();
    }
}
