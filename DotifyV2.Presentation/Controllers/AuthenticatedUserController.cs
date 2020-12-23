using System.Threading.Tasks;
using DotifyV2.Presentation.Authentication;
using DotifyV2.Presentation.Filters;
using DotifyV2.Presentation.Models;
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
    }
}
