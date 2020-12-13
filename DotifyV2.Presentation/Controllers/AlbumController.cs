using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Presentation.Models;
using DotifyV2.Presentation.Exceptions;
using DotifyV2.Presentation.Filters;

namespace DotifyV2.Presentation.Controllers
{
    [Route("api/albums")]
    [ApiController]
    [Authorize]
    public class AlbumController : Controller
    {
        readonly IAlbumCollection _albumCollection;

        public AlbumController(IAlbumCollection albumCollection)
        {
            _albumCollection = albumCollection;
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
    }
}
