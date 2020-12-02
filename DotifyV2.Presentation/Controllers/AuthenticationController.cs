using Microsoft.AspNetCore.Mvc;
using DotifyV2.Application.Services.Interfaces;
using System.Threading.Tasks;
using DotifyV2.Presentation.Models;
using DotifyV2.Presentation.Exceptions;
using System.Net;

namespace DotifyV2.Presentation.Controllers
{
	[ApiController]
	[Route("/api")]
	public class AuthenticationController : ControllerBase
	{
		readonly IAuthenticationService _authenticationService;

		public AuthenticationController(IAuthenticationService authenticationService)
		{
			_authenticationService = authenticationService;
		}

		[HttpPost("/authenticate")]
		public async Task<LoginResponseBody> LoginAsync([FromBody]LoginRequestBody loginRequest)
		{
			var authResult = await _authenticationService.AuthenticateAsync(loginRequest.Username, loginRequest.Password);

			if (!authResult.Success)
			{
				throw new HttpException(HttpStatusCode.Unauthorized);
			}

			return new LoginResponseBody
			{
				ApiToken = authResult.ApiToken
			};
		}
	}
}
