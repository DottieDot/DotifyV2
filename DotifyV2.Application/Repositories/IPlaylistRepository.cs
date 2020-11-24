using System.Collections.Generic;
using System.Threading.Tasks;
using DotifyV2.Domain.Models;

namespace DotifyV2.Application.Repositories
{
	public interface IPlaylistRepository : ICrudRepository<PlaylistDescription, Playlist>
	{
		Task<IEnumerable<PlaylistDescription>> GetPlaylistsByUserIdAsync(int userId);
	}
}
