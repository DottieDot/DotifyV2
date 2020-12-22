using System.Threading.Tasks;

namespace DotifyV2.Application.Models.Interfaces
{
    public interface ISong : ILikeable
    {
        int Id { get; }
        string Name { get; }
        int Duration { get; }
        string FileName { get; }

        Task<IAlbum> GetAlbumAsync();
    }
}
