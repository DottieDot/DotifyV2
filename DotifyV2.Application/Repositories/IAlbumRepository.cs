using System.Collections.Generic;
using System.Threading.Tasks;
using DotifyV2.Domain.Models;

namespace DotifyV2.Application.Repositories
{
	public interface IAlbumRepository : ICrudRepository<AlbumDescription, Album>
	{
		Task<IEnumerable<AlbumDescription>> GetAlbumsByArtistIdAsync(int artistId);
		Task<AlbumDescription> GetAlbumBySongIdAsync(int songId);
	}
}
