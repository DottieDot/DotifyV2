using System.Collections.Generic;
using System.Threading.Tasks;
using DotifyV2.Application.Models.Interfaces;

namespace DotifyV2.Application.Collections.Interfaces
{
    public interface IArtistCollection
    {
        Task<IArtist> GetArtistByIdAsync(int artistId);

        Task<IEnumerable<int>> GetLikedArtistIdsByUserIdAsync(int userId);
    }
}
