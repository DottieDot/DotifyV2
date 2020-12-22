using System.Threading.Tasks;
using System.Collections.Generic;

namespace DotifyV2.Application.Models.Interfaces
{
    public interface IAlbum : ILikeable
    {
        int Id { get; }
        string Name { get; }
        string CoverArt { get; }

        Task<IArtist> GetArtistAsync();

        Task<IEnumerable<ISong>> GetSongsAsync();
    }
}
