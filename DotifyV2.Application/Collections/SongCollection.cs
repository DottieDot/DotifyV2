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
    public class SongCollection : ISongCollection
    {
        readonly ISongRepository _songRepository;
        readonly DependencyMapper _dependencyMapper;

        public SongCollection(ISongRepository songRepository, DependencyMapper dependencyMapper)
        {
            _songRepository = songRepository;
            _dependencyMapper = dependencyMapper;
        }

        public async Task<IEnumerable<ISong>> GetSongsByAlbumIdAsync(int albumId)
        {
            var songs = await _songRepository.GetSongsFromAlbumIdAsync(albumId);
            return songs.Select(song => _dependencyMapper.Construct<Song>(song));
        }

        public async Task<ISong> GetSongByIdAsync(int songId)
        {
            var data = await _songRepository.GetSongByIdAsync(songId);
            return data != null ? _dependencyMapper.Construct<Song>(data) : null;
        }

        public Task<IEnumerable<int>> GetLikedSongIdsByUserIdAsync(int userId)
            => _songRepository.GetLikedSongIdsByUserIdAsync(userId);
    }
}
