using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Presentation.Exceptions;
using DotifyV2.Presentation.Filters;
using DotifyV2.Presentation.Authentication;

namespace DotifyV2.Presentation.Controllers
{
    [Route("api/songs/{id}/likes")]
    [ApiController]
    [Authorize]
    public class SongLikesController : Controller
    {
        readonly ISongCollection _songCollection;
        readonly AuthenticatedUser _authenticatedUser;

        public SongLikesController(ISongCollection songCollection, AuthenticatedUser authenticatedUser)
        {
            _songCollection = songCollection;
            _authenticatedUser = authenticatedUser;
        }

        [HttpPost]
        public async Task<bool> Post(int id)
        {
            var user = await _authenticatedUser.GetUserAsync();

            var song = await _songCollection.GetSongByIdAsync(id);
            if (song == null)
            {
                throw new HttpException(HttpStatusCode.NotFound);
            }

            return await song.LikeAsync(user.Id);
        }

        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            var user = await _authenticatedUser.GetUserAsync();

            var song = await _songCollection.GetSongByIdAsync(id);
            if (song == null)
            {
                throw new HttpException(HttpStatusCode.NotFound);
            }

            return await song.RemoveLikeAsync(user.Id);
        }
    }
}
