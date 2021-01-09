using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Presentation.Models;
using DotifyV2.Presentation.Exceptions;
using DotifyV2.Presentation.Filters;
using DotifyV2.Presentation.Authentication;

namespace DotifyV2.Presentation.Controllers
{
    [Route("api/songs")]
    [ApiController]
    [Authorize]
    public class SongController : Controller
    {
        readonly ISongCollection _songCollection;
        readonly IAlbumCollection _albumCollection;
        readonly AuthenticatedUser _authenticatedUser;

        public SongController(ISongCollection songCollection, IAlbumCollection albumCollection, AuthenticatedUser authenticatedUser)
        {
            _songCollection = songCollection;
            _albumCollection = albumCollection;
            _authenticatedUser = authenticatedUser;
        }

        [HttpPost()]
        [IsArtist]
        public async Task<SongResponse> Create([FromBody] CreateSongRequest request)
        {
            var artist = await _authenticatedUser.GetArtistAsync();
            var album = await _albumCollection.GetAlbumByIdAsync(request.AlbumId);
            if ((await album.GetArtistAsync()).Id != artist.Id)
            {
                throw new HttpException(HttpStatusCode.Unauthorized);
            }

            var song = await album.CreateSongAsync(request.Name, request.Duration);
            if (song == null)
            {
                throw new HttpException(HttpStatusCode.InternalServerError);
            }

            return await SongResponse.CreateFromSongAsync(song);
        }


        [HttpPatch("{id}")]
        [IsArtist]
        public async Task<bool> UpdateName(int id, [FromBody] UpdateSongRequest request)
        {
            var artist = await _authenticatedUser.GetArtistAsync();
            var song = await _songCollection.GetSongByIdAsync(id);

            if ((await song.GetArtistAsync()).Id != artist.Id)
            {
                throw new HttpException(HttpStatusCode.Unauthorized);
            }

            song.Name = request.Name;
            song.Duration = request.Durtion;

            return await song.SaveAsync();
        }

        [HttpDelete("{id}")]
        [IsArtist]
        public async Task<bool> Delete(int id)
        {
            var artist = await _authenticatedUser.GetArtistAsync();
            var song = await _songCollection.GetSongByIdAsync(id);

            if ((await song.GetArtistAsync()).Id != artist.Id)
            {
                throw new HttpException(HttpStatusCode.Unauthorized);
            }

            return await song.DeleteAsync();
        }
    }
}
