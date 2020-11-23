using System.Collections.Generic;
using System.Threading.Tasks;
using DotifyV2.Domain.Models;

namespace DotifyV2.Application.Repositories
{
	public interface SongRepository : ICrudRepository<Song>
	{
		Task<IEnumerable<Song>> GetSongsByAlbumIdAsync(int albumId);
		Task<IEnumerable<Song>> GetSongsByPlaylistIdAsync(int songId);
	}
}
