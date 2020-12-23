using System.Security.Claims;
using System.Threading.Tasks;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Application.Models.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DotifyV2.Presentation.Authentication
{
    public class AuthenticatedUser
    {
        IHttpContextAccessor _httpContextAccessor;
        IUserCollection _userCollection;

        public AuthenticatedUser(IHttpContextAccessor httpContextAccessor, IUserCollection userCollection)
        {
            _httpContextAccessor = httpContextAccessor;
            _userCollection = userCollection;
        }

        public int GetUserId()
        {
            var claim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            return int.Parse(claim.Value);
        }

        public Task<IUser> GetUserAsync()
            => _userCollection.GetUserByIdAsync(GetUserId());
    }
}
