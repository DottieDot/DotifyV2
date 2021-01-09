using System.Collections.Generic;
using System.Threading.Tasks;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Application.Models;
using DotifyV2.Application.Models.Interfaces;
using DotifyV2.Application.Repositories;
using DotifyV2.Common;
using DotifyV2.Application.DTOs;

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

        public async Task<IArtist> CreateArtistAsync(int userId, string name)
        {
            var data = await _artistRepository.CreateArtistAsync(new NewArtistDataDto
            {
                UserId = userId,
                Name = name,
            });
            return data != null ? _dependencyMapper.Construct<Artist>(data) : null;
        }

        public async Task<IArtist> GetArtistByIdAsync(int artistId)
        {
            var data = await _artistRepository.GetArtistByIdAsync(artistId);
            return data != null ? _dependencyMapper.Construct<Artist>(data) : null;
        }

        public async Task<IArtist> GetArtistBySongIdAsync(int songId)
        {
            var data = await _artistRepository.GetArtistBySongIdAsync(songId);
            return data != null ? _dependencyMapper.Construct<Artist>(data) : null;
        }

        public async Task<IArtist> GetArtistByUserIdAsync(int userId)
        {
            var data = await _artistRepository.GetArtistByUserIdAsync(userId);
            return data != null ? _dependencyMapper.Construct<Artist>(data) : null;
        }

        public Task<IEnumerable<int>> GetLikedArtistIdsByUserIdAsync(int userId)
            => _artistRepository.GetLikedArtistIdsByUserIdAsync(userId);
    }
}
