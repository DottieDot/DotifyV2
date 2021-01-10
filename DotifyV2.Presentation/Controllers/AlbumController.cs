using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Presentation.Models;
using DotifyV2.Presentation.Exceptions;
using DotifyV2.Presentation.Filters;
using DotifyV2.Presentation.Authentication;
using DotifyV2.Presentation.Models.Descriptions;

namespace DotifyV2.Presentation.Controllers
{
    [Route("api/albums")]
    [ApiController]
    [Authorize]
    public class AlbumController : Controller
    {
        readonly IAlbumCollection _albumCollection;
        readonly AuthenticatedUser _authenticatedUser;

        public AlbumController(IAlbumCollection albumCollection, AuthenticatedUser authenticatedUser)
        {
            _albumCollection = albumCollection;
            _authenticatedUser = authenticatedUser;
        }

        [HttpGet("{id}")]
        public async Task<AlbumResponse> Get(int id)
        {
            var album = await _albumCollection.GetAlbumByIdAsync(id);
            if (album == null)
            {
                throw new HttpException(HttpStatusCode.NotFound);
            }

            return await AlbumResponse.CreateFromAlbumAsync(album);
        }

        [HttpPost()]
        [IsArtist]
        public async Task<AlbumResponse> Create([FromBody] CreateAlbumRequest request)
        {
            var artist = await _authenticatedUser.GetArtistAsync();
            var album = await artist.CreateAlbumAsync(request.Name);
            if (album == null)
            {
                throw new HttpException(HttpStatusCode.InternalServerError);
            }
            return await AlbumResponse.CreateFromAlbumAsync(album);
        }

        [HttpPatch("/api/albums/{id}/name")]
        [IsArtist]
        public async Task<bool> UpdateName(int id, [FromBody] ChangeAlbumNameRequest request)
        {
            var artist = await _authenticatedUser.GetArtistAsync();
            var album = await _albumCollection.GetAlbumByIdAsync(id);

            if ((await album.GetArtistAsync()).Id != artist.Id)
            {
                throw new HttpException(HttpStatusCode.Unauthorized);
            }

            album.Name = request.Name;

            return await album.SaveAsync();
        }

        [HttpDelete("{id}")]
        [IsArtist]
        public async Task<bool> Delete(int id)
        {
            var artist = await _authenticatedUser.GetArtistAsync();
            var album = await _albumCollection.GetAlbumByIdAsync(id);

            if ((await album.GetArtistAsync()).Id != artist.Id)
            {
                throw new HttpException(HttpStatusCode.Unauthorized);
            }

            return await album.DeleteAsync();
        }

        [HttpGet()]
        public async Task<IEnumerable<AlbumDescription>> Index([FromQuery] IndexRequest request)
        {
            var albums = await _albumCollection.GetAllAlbumsAsync(request.Offset, request.Count);

            return albums.Select(album => new AlbumDescription(album));
        }
    }
}
