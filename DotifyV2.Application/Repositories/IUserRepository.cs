using System.Threading.Tasks;
using DotifyV2.Domain.Models;

namespace DotifyV2.Application.Repositories
{
	interface IUserRepository : ICrudRepository<User>
	{
		Task<User> GetUserByPlaylistIdAsync(int playlistId);
		Task<User> GetUserByEmailAsync(string email);
		Task<User> GetUserByApiTokenAsync(string apiToken);
	}
}
