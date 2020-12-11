using System.Threading.Tasks;
using DotifyV2.Application.DTOs;

namespace DotifyV2.Application.Repositories
{
    public interface IArtistRepository
    {
        Task<ArtistDataDto> GetArtistByIdAsync(int id);
    }
}
