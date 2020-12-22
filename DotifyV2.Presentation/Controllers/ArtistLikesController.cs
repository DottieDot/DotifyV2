using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Presentation.Exceptions;
using DotifyV2.Presentation.Filters;
using DotifyV2.Presentation.Identities;

namespace DotifyV2.Presentation.Controllers
{
    [Route("api/artists/{id}/likes")]
    [ApiController]
    [Authorize]
    public class ArtistLikesController : Controller
    {
        readonly IArtistCollection _artistCollection;

        public ArtistLikesController(IArtistCollection artistCollection)
        {
            _artistCollection = artistCollection;
        }

        [HttpPost]
        public async Task<bool> Post(int id)
        {
            var identity = HttpContext.User.Identity as BearerTokenUserIdentity;
            var user = identity.User;

            var artist = await _artistCollection.GetArtistByIdAsync(id);
            if (artist == null)
            {
                throw new HttpException(HttpStatusCode.NotFound);
            }

            return await artist.LikeAsync(user.Id);
        }

        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            var identity = HttpContext.User.Identity as BearerTokenUserIdentity;
            var user = identity.User;

            var artist = await _artistCollection.GetArtistByIdAsync(id);
            if (artist == null)
            {
                throw new HttpException(HttpStatusCode.NotFound);
            }

            return await artist.RemoveLikeAsync(user.Id);
        }
    }
}
