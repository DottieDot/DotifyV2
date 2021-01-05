using System.Threading.Tasks;
using DotifyV2.Application.Models.Interfaces;
using System.Collections.Generic;

namespace DotifyV2.Application.Collections.Interfaces
{
    public interface IAlbumCollection
    {
        Task<IAlbum> CreateAlbumAsync(int artistId, string name);

        Task DeleteAlbumsByArtistIdAsync(int artistId);

        Task<IEnumerable<IAlbum>> GetAlbumsByArtistIdAsync(int artistId);

        Task<IAlbum> GetAlbumByIdAsync(int albumId);

        Task<IEnumerable<int>> GetLikedAlbumIdsByUserIdAsync(int userId);
    }
}
