namespace BookingClone.API.Authentication;

public sealed class ApiKeyEndpointFilter : IEndpointFilter
{
    private readonly IConfiguration _configuration;

    public ApiKeyEndpointFilter(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(AuthConstants.ApiKeyHeaderName, out var extractedApiKey))
        {
            context.HttpContext.Response.StatusCode = 401;
            await context.HttpContext.Response.WriteAsync("API Key is missing. Check your headers.");
            return TypedResults.Unauthorized();
        }

        var apiKey = _configuration.GetValue<string>(AuthConstants.ApiKeySectionName);

        if (!apiKey.Equals(extractedApiKey))
        {
            context.HttpContext.Response.StatusCode = 401;
            await context.HttpContext.Response.WriteAsync("Invalid API Key.");
            return TypedResults.Unauthorized();
        }

        return await next(context);
    }
}
