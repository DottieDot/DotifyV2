using System.Threading.Tasks;

namespace DotifyV2.Application.Models.Interfaces
{
    public interface IAlbum
    {
        int Id { get; }
        string Name { get; }
        string CoverArt { get; }

        Task<IArtist> GetArtistAsync();
    }
}
