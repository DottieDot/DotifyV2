using System.Collections.Generic;
using System.Threading.Tasks;
using DotifyV2.Domain.Models;

namespace DotifyV2.Application.Repositories
{
	public interface ISongRepository : ICrudRepository<SongDescription, Song>
	{
		Task<IEnumerable<SongDescription>> GetSongsByAlbumIdAsync(int albumId);
		Task<IEnumerable<SongDescription>> GetSongsByPlaylistIdAsync(int songId);
	}
}
