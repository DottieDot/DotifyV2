using Microsoft.AspNetCore.Mvc;
using DotifyV2.Application.Services.Interfaces;
using System.Threading.Tasks;
using DotifyV2.Presentation.Models;
using DotifyV2.Presentation.Exceptions;
using System.Net;
using DotifyV2.Application.Collections.Interfaces;

namespace DotifyV2.Presentation.Controllers
{
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		readonly IUserCollection _userCollection;

		public AuthenticationController(IUserCollection userCollection)
		{
			_userCollection = userCollection;
		}

		[HttpPost("/api/authenticate")]
		public async Task<LoginResponseBody> LoginAsync([FromBody]LoginRequestBody loginRequest)
		{
			var user = await _userCollection.GetUserByUsernameAsync(loginRequest.Username);

			string apiToken = user.VerifyPassword(loginRequest.Password);
			if (apiToken == null)
			{
				throw new HttpException(HttpStatusCode.Unauthorized);
			}

			return new LoginResponseBody
			{
				ApiToken = apiToken
			};
		}
	}
}
