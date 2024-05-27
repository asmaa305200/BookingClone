using BookingClone.Application.Features.continent.commands.AddContinent;
using BookingClone.Application.Features.continent.commands.DeleteContinent;
using BookingClone.Application.Features.continent.commands.UpdateContinent;
using BookingClone.Application.Features.continent.queries.GetAllcontinent;
using BookingClone.Application.Features.continent.queries.GetContinentById;
using BookingClone.Application.Features.country.commands.AddCountry;
using BookingClone.Application.Features.country.commands.DeleteCountry;
using BookingClone.Application.Features.country.commands.UpdateCountry;
using BookingClone.Application.Features.country.queries.GitAllCountries;
using BookingClone.Application.Features.country.queries.GitCountryById;
using BookingClone.Infrastructure.Data;
using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingClone.API.Controllers.V1;
[Route("api/[controller]")]
[ApiController]
public sealed class CountriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CountriesController(IMediator mediator)
        => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAllCountry(CancellationToken ct)
    {
        return Ok(await _mediator.Send(new GetAllCountriesQuery(), ct));
    }

    [HttpGet("{id}", Name = "Get_[controller]")]

    public async Task<IActionResult> GetCountryById(int id, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetCountryByIdQuery(id), ct);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddCountry([FromBody] AddCountryCommmand addCountryCommmand, CancellationToken ct)
    {
        var result = await _mediator.Send(addCountryCommmand, ct);
        return CreatedAtRoute("Get_Countries", new { id = result.ID }, result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCountry([FromBody] UpdateCountryCommmand updateCountryCommmand, CancellationToken ct)
    {
        var result = await _mediator.Send(updateCountryCommmand, ct);
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCountry(int id, CancellationToken ct)
    {
        var result = await _mediator.Send(new DeleteCountryCommmand(id), ct);
        return result <= 0 ? NotFound() : NoContent();
    }

}
