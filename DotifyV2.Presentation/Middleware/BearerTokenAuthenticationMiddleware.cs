using System;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Presentation.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using DotifyV2.Presentation.Exceptions;
using System.Net;

namespace DotifyV2.Presentation.Middleware
{
	public class BearerTokenAuthenticationMiddleware
	{
		readonly RequestDelegate _next;

		public BearerTokenAuthenticationMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context, IUserCollection userCollection)
		{
			var request = context.Request;

			if (!request.Headers.ContainsKey("Authorization"))
			{
				await _next(context);
				return;
			}

			AuthenticationHeaderValue authorizationHeader = AuthenticationHeaderValue.Parse(request.Headers["Authorization"]);

			if (authorizationHeader.Scheme != "Bearer")
			{
				throw new HttpException(HttpStatusCode.BadRequest, "Invalid authorization scheme");
			}

			if (String.IsNullOrEmpty(authorizationHeader.Parameter))
			{
				throw new HttpException(HttpStatusCode.BadRequest, "Missing authorization token");
			}

			string token = authorizationHeader.Parameter;
			var user = await userCollection.GetUserByApiTokenAsync(token);
			if (user == null)
			{
				throw new HttpException(HttpStatusCode.Unauthorized, "Invalid authorization token");
			}

			var identity = new ClaimsIdentity(new BearerTokenUserIdentity(user));
			identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
			context.User = new ClaimsPrincipal(identity);

			await _next(context);
		}
	}
}
