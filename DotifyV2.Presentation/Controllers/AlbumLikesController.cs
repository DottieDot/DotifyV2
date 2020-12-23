using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Presentation.Exceptions;
using DotifyV2.Presentation.Filters;
using DotifyV2.Presentation.Authentication;

namespace DotifyV2.Presentation.Controllers
{
    [Route("api/albums/{id}/likes")]
    [ApiController]
    [Authorize]
    public class AlbumLikesController : Controller
    {
        readonly IAlbumCollection _albumCollection;
        readonly AuthenticatedUser _authenticatedUser;

        public AlbumLikesController(IAlbumCollection albumCollection, AuthenticatedUser authenticatedUser)
        {
            _albumCollection = albumCollection;
            _authenticatedUser = authenticatedUser;
        }

        [HttpPost]
        public async Task<bool> Post(int id)
        {
            var user = await _authenticatedUser.GetUserAsync();

            var album = await _albumCollection.GetAlbumByIdAsync(id);
            if (album == null)
            {
                throw new HttpException(HttpStatusCode.NotFound);
            }

            return await album.LikeAsync(user.Id);
        }

        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            var user = await _authenticatedUser.GetUserAsync();

            var album = await _albumCollection.GetAlbumByIdAsync(id);
            if (album == null)
            {
                throw new HttpException(HttpStatusCode.NotFound);
            }

            return await album.RemoveLikeAsync (user.Id);
        }
    }
}
