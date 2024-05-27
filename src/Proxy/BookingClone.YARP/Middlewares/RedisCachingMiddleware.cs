using Microsoft.Extensions.Caching.Distributed;

/// <summary>
/// Caching middleware from Redis
/// </summary>
internal sealed class RedisCachingMiddleware
{
    private readonly IDistributedCache _redisCache;
    private readonly ILogger<RedisCachingMiddleware> _logger;

    public RedisCachingMiddleware(IDistributedCache redisCache, ILogger<RedisCachingMiddleware> logger)
    {
        _redisCache = redisCache;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        string path = context.Request.Path.Value!;
        string? cachedEntry = await _redisCache.GetStringAsync(path);

        if (cachedEntry is not null)
        {
            _logger.LogInformation("Cache Hit for {path}", path);
            context.Response.StatusCode = StatusCodes.Status200OK;
            await context.Response.WriteAsync(cachedEntry);
            return;
        }

        _logger.LogInformation("Cache Miss for {path}", path);
        await next(context);
    }
}