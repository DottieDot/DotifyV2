using System.Collections.Generic;
using System.Threading.Tasks;
using DotifyV2.Application.Models.Interfaces;

namespace DotifyV2.Application.Collections.Interfaces
{
    public interface IArtistCollection
    {
        Task<IArtist> CreateArtistAsync(int userId, string name);

        Task<IArtist> GetArtistByIdAsync(int artistId);

        Task<IArtist> GetArtistByUserIdAsync(int userId);

        Task<IArtist> GetArtistBySongIdAsync(int songId);

        Task<IEnumerable<int>> GetLikedArtistIdsByUserIdAsync(int userId);

        Task<IEnumerable<IArtist>> GetAllArtistsAsync(int offset, int count);
    }
}
