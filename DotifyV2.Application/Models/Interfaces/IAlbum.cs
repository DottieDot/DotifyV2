using System.Threading.Tasks;
using System.Collections.Generic;

namespace DotifyV2.Application.Models.Interfaces
{
    public interface IAlbum : ILikeable
    {
        int Id { get; }
        string Name { get; set; }
        string CoverArt { get; }

        Task<ISong> CreateSongAsync(string name, int duration);

        Task<IArtist> GetArtistAsync();

        Task<IEnumerable<ISong>> GetSongsAsync();

        Task<bool> SaveAsync();

        Task<bool> DeleteAsync();
    }
}
