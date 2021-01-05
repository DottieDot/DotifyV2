using System;
using System.Net;
using System.Threading.Tasks;
using DotifyV2.Presentation.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace DotifyV2.Presentation.Filters
{
    public class IsArtist : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var authenticatedUser = context.HttpContext.RequestServices.GetService<AuthenticatedUser>();

            var artist = await authenticatedUser.GetArtistAsync();
            if (artist == null)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new JsonResult("Unauthorized");
            }

            await next();
        }
    }
}
