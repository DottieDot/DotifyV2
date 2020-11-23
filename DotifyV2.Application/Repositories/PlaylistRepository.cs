using System.Collections.Generic;
using System.Threading.Tasks;
using DotifyV2.Domain.Models;

namespace DotifyV2.Application.Repositories
{
	public interface PlaylistRepository : ICrudRepository<Playlist>
	{
		Task<IEnumerable<Playlist>> GetPlaylistsByUserIdAsync(int userId);
	}
}
