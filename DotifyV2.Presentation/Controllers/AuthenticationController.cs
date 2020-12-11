using System.Net;
using System.Threading.Tasks;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Presentation.Exceptions;
using DotifyV2.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

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
		public async Task<LoginResponse> LoginAsync([FromBody]LoginRequest loginRequest)
		{
			var user = await _userCollection.GetUserByUsernameAsync(loginRequest.Username);

			string apiToken = user.VerifyPassword(loginRequest.Password);
			if (apiToken == null)
			{
				throw new HttpException(HttpStatusCode.Unauthorized);
			}

			return new LoginResponse
			{
				ApiToken = apiToken
			};
		}
	}
}
