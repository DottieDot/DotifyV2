using System.Threading.Tasks;

namespace DotifyV2.Application.Models.Interfaces
{
    public interface ILikeable
    {
        Task<bool> LikeAsync(int userId);

        Task<bool> RemoveLikeAsync(int userId);
    }
}
