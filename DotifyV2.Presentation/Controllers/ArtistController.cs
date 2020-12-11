using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Presentation.Models;
using DotifyV2.Presentation.Exceptions;
using DotifyV2.Presentation.Filters;

namespace DotifyV2.Presentation.Controllers
{
    [Route("api/artists")]
    [ApiController]
    [Authorize]
    public class ArtistController : Controller
    {
        readonly IArtistCollection _artistCollection;

        public ArtistController(IArtistCollection artistCollection)
        {
            _artistCollection = artistCollection;
        }

        [HttpGet("{id}")]
        public async Task<ArtistResponse> Get(int id)
        {
            var artist = await _artistCollection.GetArtistById(id);
            if (artist == null)
            {
                throw new HttpException(HttpStatusCode.NotFound);
            }

            return await ArtistResponse.CreateFromArtistAsync(artist);
        }
    }
}
