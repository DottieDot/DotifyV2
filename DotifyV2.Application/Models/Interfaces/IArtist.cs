using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotifyV2.Application.Models.Interfaces
{
    public interface IArtist : ILikeable
    {
        int Id { get; }
        string Name { get; }
        string Picture { get; }

        Task<IEnumerable<IAlbum>> GetAlbumsAsync();

        Task<bool> DeleteAsync();
    }
}
