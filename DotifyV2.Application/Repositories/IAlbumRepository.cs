using System.Threading.Tasks;
using System.Collections.Generic;
using DotifyV2.Application.DTOs;

namespace DotifyV2.Application.Repositories
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<AlbumDataDto>> GetAlbumsByArtistIdAsync(int artistId);

        Task<AlbumDataDto> GetAlbumByIdAsync(int albumId);
    }
}
