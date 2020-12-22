using System.Collections.Generic;
using System.Threading.Tasks;
using DotifyV2.Application.Models.Interfaces;

namespace DotifyV2.Application.Collections.Interfaces
{
    public interface ISongCollection
    {
        Task<IEnumerable<ISong>> GetSongsByAlbumIdAsync(int albumId);

        Task<ISong> GetSongByIdAsync(int songId);
    }
}
