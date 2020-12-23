using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Presentation.Exceptions;
using DotifyV2.Presentation.Filters;
using DotifyV2.Presentation.Authentication;

namespace DotifyV2.Presentation.Controllers
{
    [Route("api/artists/{id}/likes")]
    [ApiController]
    [Authorize]
    public class ArtistLikesController : Controller
    {
        readonly IArtistCollection _artistCollection;
        readonly AuthenticatedUser _authenticatedUser;

        public ArtistLikesController(IArtistCollection artistCollection, AuthenticatedUser authenticatedUser)
        {
            _artistCollection = artistCollection;
            _authenticatedUser = authenticatedUser;
        }

        [HttpPost]
        public async Task<bool> Post(int id)
        {
            var user = await _authenticatedUser.GetUserAsync();

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
            var user = await _authenticatedUser.GetUserAsync();

            var artist = await _artistCollection.GetArtistByIdAsync(id);
            if (artist == null)
            {
                throw new HttpException(HttpStatusCode.NotFound);
            }

            return await artist.RemoveLikeAsync(user.Id);
        }
    }
}
