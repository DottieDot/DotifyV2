using System.Collections.Generic;
using System.Threading.Tasks;
using DotifyV2.Domain.Models;

namespace DotifyV2.Application.Repositories
{
	public interface IAlbumRepository : ICrudRepository<Album>
	{
		Task<IEnumerable<Album>> GetAlbumsByArtistIdAsync(int artistId);
		Task<Album> GetAlbumBySongIdAsync(int songId);
	}
}
