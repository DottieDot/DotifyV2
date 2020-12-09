using System.Net;
using System.Threading.Tasks;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Presentation.Exceptions;
using DotifyV2.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotifyV2.Presentation.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        IUserCollection _userCollection;

        public UserController(IUserCollection userCollection)
        {
            _userCollection = userCollection;
        }

        [HttpPost("api/users")]
        public async Task<SignUpResponse> Create([FromBody] SignupRequest request)
        {
            if (_userCollection.GetUserByUsernameAsync(request.Username) != null)
            {
                throw new HttpException(HttpStatusCode.BadRequest, "A user already exists with this username");
            }

            var user = await _userCollection.CreateUserAsync(request.Username, request.Password);
            if (user == null)
            {
                throw new HttpException(HttpStatusCode.InternalServerError);
            }

            return new SignUpResponse
            {
                ApiToken = user.VerifyPassword(request.Password)
            };
        }
    }
}
