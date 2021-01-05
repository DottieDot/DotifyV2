using System.Net;
using System.Threading.Tasks;
using DotifyV2.Presentation.Authentication;
using DotifyV2.Presentation.Filters;
using DotifyV2.Presentation.Models;
using DotifyV2.Presentation.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace DotifyV2.Presentation.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class AuthenticatedUserController : Controller
    {
        AuthenticatedUser _authenticatedUser;

        public AuthenticatedUserController(AuthenticatedUser authenticatedUser)
        {
            _authenticatedUser = authenticatedUser;
        }

        [HttpGet]
        public async Task<AuthenticatedUserResponse> Get()
        {
            var user = await _authenticatedUser.GetUserAsync();
            return await AuthenticatedUserResponse.CreateFromUserAsync(user);
        }

        [HttpPatch("/api/user/username")]
        public async Task<bool> UpdateUsername([FromBody] ChangeUsernameRequest request)
        {
            var user = await _authenticatedUser.GetUserAsync();
            if (user.VerifyPassword(request.Password) == null)
            {
                throw new HttpException(HttpStatusCode.Unauthorized, "Incorrect password.");
            }

            user.Username = request.Username;
            await user.SaveAsync();
            return true;
        }

        [HttpPatch("/api/user/password")]
        public async Task<bool> UpdatePassword([FromBody] ChangePasswordRequest request)
        {
            var user = await _authenticatedUser.GetUserAsync();
            if (user.VerifyPassword(request.CurrentPassword) == null)
            {
                throw new HttpException(HttpStatusCode.Unauthorized, "Incorrect password.");
            }

            if (user.SetPassword(request.NewPassword))
            {
                await user.SaveAsync();
                return true;
            }

            return false;
        }
    }
}
