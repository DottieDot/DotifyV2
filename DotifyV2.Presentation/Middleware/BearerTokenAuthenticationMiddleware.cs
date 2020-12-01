using System;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using DotifyV2.Application.Services.Interfaces;
using DotifyV2.Presentation.Identities;
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

		public async Task InvokeAsync(HttpContext context, IAuthenticationService authenticationService)
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
			var authResult = await authenticationService.AuthenticateAsync(token);
			if (!authResult.Success)
			{
				throw new HttpException(HttpStatusCode.Unauthorized, "Invalid authorization token");
			}

			var identity = new BearerTokenUserIdentity(authResult.Data);
			context.User = new ClaimsPrincipal(identity);

			await _next(context);
		}
	}
}
