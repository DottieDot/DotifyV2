using System.Threading.Tasks;

namespace DotifyV2.Application.Models.Interfaces
{
    public interface ISong : ILikeable
    {
        int Id { get; }
        string Name { get; set; }
        int Duration { get; set; }
        string FileName { get; }

        Task<IAlbum> GetAlbumAsync();

        Task<IArtist> GetArtistAsync();

        Task<bool> SaveAsync();

        Task<bool> DeleteAsync();
    }
}
