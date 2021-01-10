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
    [Route("api/artists")]
    [ApiController]
    [Authorize]
    public class ArtistController : Controller
    {
        readonly IArtistCollection _artistCollection;
        readonly AuthenticatedUser _authenticatedUser;

        public ArtistController(IArtistCollection artistCollection, AuthenticatedUser authenticatedUser)
        {
            _artistCollection = artistCollection;
            _authenticatedUser = authenticatedUser;
        }

        [HttpGet("{id}")]
        public async Task<ArtistResponse> Get(int id)
        {
            var artist = await _artistCollection.GetArtistByIdAsync(id);
            if (artist == null)
            {
                throw new HttpException(HttpStatusCode.NotFound);
            }

            return await ArtistResponse.CreateFromArtistAsync(artist);
        }

        [HttpDelete()]
        public async Task<bool> Delete()
        {
            var user = await _authenticatedUser.GetUserAsync();
            var artist = await user.GetArtistAsync();

            return await artist.DeleteAsync();
        }

        [HttpPost()]
        public async Task<ArtistResponse> Create([FromBody] CreateArtistRequest request)
        {
            var user = await _authenticatedUser.GetUserAsync();
            var artist = await user.GetArtistAsync();

            if (artist != null)
            {
                throw new HttpException(HttpStatusCode.Unauthorized);
            }
            var result = await _artistCollection.CreateArtistAsync(user.Id, request.Name);
            if (result == null)
            {
                throw new HttpException(HttpStatusCode.InternalServerError);
            }
            return await ArtistResponse.CreateFromArtistAsync(result);
        }

        [HttpGet()]
        public async Task<IEnumerable<ArtistDescription>> Index([FromQuery] IndexRequest request)
        {
            var artists = await _artistCollection.GetAllArtistsAsync(request.Offset, request.Count);

            return artists.Select(artist => new ArtistDescription(artist));
        }
    }
}
