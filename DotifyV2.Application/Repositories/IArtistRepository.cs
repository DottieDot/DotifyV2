using System.Collections.Generic;
using System.Threading.Tasks;
using DotifyV2.Application.DTOs;

namespace DotifyV2.Application.Repositories
{
    public interface IArtistRepository
    {
        Task<bool> DeleteArtistAsync(int artistId);

        Task<ArtistDataDto> CreateArtistAsync(NewArtistDataDto dataDto);
        
        Task<ArtistDataDto> GetArtistByIdAsync(int id);

        Task<ArtistDataDto> GetArtistByUserIdAsync(int userId);

        Task<ArtistDataDto> GetArtistBySongIdAsync(int songId);

        Task<bool> AddUserLikeAsync(int artistId, int userId);

        Task<bool> RemoveUserLikeAsync(int artistId, int userId);

        Task<IEnumerable<int>> GetLikedArtistIdsByUserIdAsync(int userId);
    }
}
