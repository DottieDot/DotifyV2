using System.Threading.Tasks;
using DotifyV2.Domain.Models;

namespace DotifyV2.Application.Repositories
{
	public interface IArtistRepository : ICrudRepository<Artist>
	{
		Task<Artist> GetArtistByAlbumIdAsync(int albumId);
		Task<Artist> GetArtistBySongIdAsync(int songId);
	}
}
