using System.Collections.Generic;
using System.Threading.Tasks;
using DotifyV2.Application.DTOs;

namespace DotifyV2.Application.Repositories
{
    public interface ISongRepository
    {
        Task<IEnumerable<SongDataDto>> GetSongsFromAlbumIdAsync(int albumId);
    }
}
