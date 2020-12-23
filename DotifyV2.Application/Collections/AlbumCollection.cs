using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Application.Models;
using DotifyV2.Application.Models.Interfaces;
using DotifyV2.Application.Repositories;
using DotifyV2.Common;

namespace DotifyV2.Application.Collections
{
    public class AlbumCollection : IAlbumCollection
    {
        readonly IAlbumRepository _albumRepository;
        readonly DependencyMapper _dependencyMapper;

        public AlbumCollection(IAlbumRepository albumRepository, DependencyMapper dependencyMapper)
        {
            _albumRepository = albumRepository;
            _dependencyMapper = dependencyMapper;
        }

        public async Task<IAlbum> GetAlbumByIdAsync(int albumId)
        {
            var data = await _albumRepository.GetAlbumByIdAsync(albumId);
            return data != null ? _dependencyMapper.Construct<Album>(data) : null;
        }

        public async Task<IEnumerable<IAlbum>> GetAlbumsByArtistIdAsync(int artistId)
        {
           var albums = await _albumRepository.GetAlbumsByArtistIdAsync(artistId);
           return albums.Select(data => _dependencyMapper.Construct<Album>(data));
        }

        public Task<IEnumerable<int>> GetLikedAlbumIdsByUserIdAsync(int userId)
            => _albumRepository.GetLikedAlbumIdsByUserIdAsync(userId);
    }
}
