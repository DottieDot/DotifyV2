using System.Threading.Tasks;
using DotifyV2.Domain.Models;

namespace DotifyV2.Application.Repositories
{
	public interface IArtistRepository : ICrudRepository<ArtistDescription, Artist>
	{
		Task<ArtistDescription> GetArtistByAlbumIdAsync(int albumId);
		Task<ArtistDescription> GetArtistBySongIdAsync(int songId);
	}
}
