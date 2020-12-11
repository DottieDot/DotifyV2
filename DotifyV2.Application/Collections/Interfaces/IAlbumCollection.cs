using System.Threading.Tasks;
using DotifyV2.Application.Models.Interfaces;
using System.Collections.Generic;

namespace DotifyV2.Application.Collections.Interfaces
{
    public interface IAlbumCollection
    {
        Task<IEnumerable<IAlbum>> GetAlbumsByArtistId(int artistId);
    }
}
