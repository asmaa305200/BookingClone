using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookingClone.API.Authentication;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public sealed class ApiKeyAuthFilter : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        //if (!context.HttpContext.Request.Headers.TryGetValue(AuthConstants.ApiKeyHeaderName, out var extractedApiKey))
        //{
        //    context.Result = new UnauthorizedObjectResult("API Key is missing. Check your headers.");
        //    return;
        //}

        //var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        //var apiKey = configuration.GetValue<string>(AuthConstants.ApiKeySectionName);

        //if (!apiKey.Equals(extractedApiKey))
        //{
        //    context.Result = new UnauthorizedObjectResult("Invalid API Key.");
        //    return;
        //}
    }
}
