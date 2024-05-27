using BookingClone.Application.Features.continent.queries.getAllContinentswithoutpagination;
using BookingClone.Application.Features.country.commands.AddCountry;
using BookingClone.Application.Features.country.commands.DeleteCountry;
using BookingClone.Application.Features.country.commands.UpdateCountry;
using BookingClone.Application.Features.country.DTOs;
using BookingClone.Application.Features.country.queries.GitAllCountries;
using BookingClone.Application.Features.country.queries.GitCountryById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookingClone.Admin.Controllers;

[Authorize]
public sealed class CountryController : Controller
{
    private readonly IMediator _mediator;

    public CountryController(IMediator mediator)
        => _mediator = mediator;

    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
    {
        var reservations = await _mediator.Send(new getallcountryquery2() { Query = new(pageNumber, pageSize) }, ct);
        return View(reservations);
    }

    public async Task<IActionResult> Details(int id, CancellationToken ct)
    {
        var reservation = await _mediator.Send(new GetCountryByIdQuery(id), ct);
        return View(reservation);
    }

    public IActionResult Create()
    {
        this.ViewData["Continents"] = _mediator.Send(new GetAllContinentsQuerywithoutpagination()).Result

       .Select(c => new SelectListItem() { Text = c.Name, Value = c.ID.ToString() })
      .ToList();
        return View();
    }
       

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CountryDetailsDto request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(request);

        var newReservation = await _mediator.Send(new addcountrycommand2 { Dto = request }, ct);
        return RedirectToAction(nameof(Details), new { id = newReservation.ID });
    }



    public async Task<IActionResult> Edit(int id, CancellationToken ct)
    {
        this.ViewData["Continents"] = _mediator.Send(new GetAllContinentsQuerywithoutpagination()).Result

      .Select(c => new SelectListItem() { Text = c.Name, Value = c.ID.ToString() })
      .ToList();

        var reservations = await _mediator.Send(new GetCountryByIdQuery(id), ct);
        return View(reservations);
    }




    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CountryDetailsDto request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(request);

        await _mediator.Send(new updatecountrycommand2 { Dto = request }, ct);
        return RedirectToAction(nameof(Details), new { id = request.ID });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        await _mediator.Send(new DeleteCountryCommmand(id), ct);
        return RedirectToAction(nameof(Index));
    }

   

}
