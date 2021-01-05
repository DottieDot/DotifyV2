using System.Collections.Generic;
using System.Threading.Tasks;
using DotifyV2.Application.Models.Interfaces;

namespace DotifyV2.Application.Collections.Interfaces
{
    public interface ISongCollection
    {
        Task DeleteSongsByAlbumIdAsync(int albumId);

        Task DeleteSongsByArtistId(int artistId);

        Task<IEnumerable<ISong>> GetSongsByAlbumIdAsync(int albumId);

        Task<ISong> GetSongByIdAsync(int songId);

        Task<IEnumerable<int>> GetLikedSongIdsByUserIdAsync(int userId);
    }
}
