using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Presentation.Exceptions;
using DotifyV2.Presentation.Filters;
using DotifyV2.Presentation.Identities;

namespace DotifyV2.Presentation.Controllers
{
    [Route("api/albums/{id}/likes")]
    [ApiController]
    [Authorize]
    public class AlbumLikesController : Controller
    {
        readonly IAlbumCollection _albumCollection;

        public AlbumLikesController(IAlbumCollection albumCollection)
        {
            _albumCollection = albumCollection;
        }

        [HttpPost]
        public async Task<bool> Post(int id)
        {
            var identity = HttpContext.User.Identity as BearerTokenUserIdentity;
            var user = identity.User;

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
            var identity = HttpContext.User.Identity as BearerTokenUserIdentity;
            var user = identity.User;

            var album = await _albumCollection.GetAlbumByIdAsync(id);
            if (album == null)
            {
                throw new HttpException(HttpStatusCode.NotFound);
            }

            return await album.RemoveLikeAsync (user.Id);
        }
    }
}
