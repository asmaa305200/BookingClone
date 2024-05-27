using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace BookingClone.API.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
[ApiVersion("1.0")]
public sealed class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    /// <summary>
    /// Gets Random forecasts
    /// </summary>
    /// <returns></returns>
    [MapToApiVersion("1.0")]
    [HttpGet(Name = "GetWeatherForecastV1")]
    public WeatherForecast[] Get()
        => Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray();
}
