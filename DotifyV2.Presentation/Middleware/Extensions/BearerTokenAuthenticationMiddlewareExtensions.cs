using Microsoft.AspNetCore.Builder;
using DotifyV2.Presentation.Middleware;

namespace DotifyV2.Presentation.Middleware.Extensions
{
	public static class BearerTokenAuthenticationMiddlewareExtensions
	{
		public static IApplicationBuilder UseBearerTokenAuthentication(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<BearerTokenAuthenticationMiddleware>();
		}
	}
}
