using System.Text.Json;

using Asp.Versioning;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace BookingClone.API.Controllers.V2;

[ApiController]
[Route("api/[controller]")]
[ApiVersion("2.0")]
public sealed class WeatherForecast2Controller : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly IDistributedCache _distributedCache;

    public WeatherForecast2Controller(IDistributedCache distributedCache)
        => _distributedCache = distributedCache;

    /// <summary>
    /// Gets Random forecasts
    /// </summary>
    /// <returns></returns>
    [MapToApiVersion("2.0")]
    [HttpGet(Name = "GetWeatherForecastV2")]
    public async Task<IActionResult> Get(CancellationToken ct)
    {
        var key = HttpContext.Request.Path.Value;
        var cachedResult = await GetCachedResponseAsync(key, ct);

        if (cachedResult is not null)
            return Ok(JsonSerializer.Deserialize<List<WeatherForecast>>(cachedResult));

        var res = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();

        await CacheResponseAsync(key, res, TimeSpan.FromSeconds(50), ct);
        return Ok(res);
    }

    async Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive, CancellationToken ct = default)
    {
        if (response is null)
            return;

        var serializedResponse = JsonSerializer.Serialize(response);
        await _distributedCache.SetStringAsync(cacheKey, serializedResponse, new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = timeToLive,
        }, ct);
    }

    async Task<string?> GetCachedResponseAsync(string cacheKey, CancellationToken ct = default)
        => await _distributedCache.GetStringAsync(cacheKey, ct);
}
