using System.Collections.Generic;
using System.Threading.Tasks;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Application.Models;
using DotifyV2.Application.Models.Interfaces;
using DotifyV2.Application.Repositories;
using DotifyV2.Common;

namespace DotifyV2.Application.Collections
{
    public class ArtistCollection : IArtistCollection
    {
        readonly IArtistRepository _artistRepository;
        readonly DependencyMapper _dependencyMapper;

        public ArtistCollection(IArtistRepository artistRepository, DependencyMapper dependencyMapper)
        {
            _artistRepository = artistRepository;
            _dependencyMapper = dependencyMapper;
        }

        public async Task<IArtist> GetArtistByIdAsync(int artistId)
        {
            var data = await _artistRepository.GetArtistByIdAsync(artistId);
            return data != null ? _dependencyMapper.Construct<Artist>(data) : null;
        }

        public Task<IEnumerable<int>> GetLikedArtistIdsByUserIdAsync(int userId)
            => _artistRepository.GetLikedArtistIdsByUserIdAsync(userId);
    }
}
