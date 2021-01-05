using System.Collections.Generic;
using System.Threading.Tasks;
using DotifyV2.Application.Models.Interfaces;

namespace DotifyV2.Application.Models.Interfaces
{
	public interface IUser
	{
		int Id { get; }
		string Username { get; set; }

		bool SetPassword(string password);

		/// <summary>
		/// Checks if the password is correct for the user.
		/// </summary>
		/// <param name="password"></param>
		/// <returns>The API token for the user or null if the password is incorrect.</returns>
		string VerifyPassword(string password);

		Task<bool> SaveAsync();

		Task<IArtist> GetArtistAsync();

		Task<IEnumerable<int>> GetLikedSongIdsAsync();

		Task<IEnumerable<int>> GetLikedAlbumIdsAsync();

		Task<IEnumerable<int>> GetLikedArtistIdsAsync();
	}
}
