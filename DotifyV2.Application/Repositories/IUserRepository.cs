using System.Threading.Tasks;
using DotifyV2.Domain.Models;

namespace DotifyV2.Application.Repositories
{
	interface IUserRepository : ICrudRepository<UserDescription, User>
	{
		Task<UserDescription> GetUserByPlaylistIdAsync(int playlistId);
		Task<UserDescription> GetUserByUsernameAsync(string username);
		Task<UserDescription> GetUserByApiTokenAsync(string apiToken);
	}
}
