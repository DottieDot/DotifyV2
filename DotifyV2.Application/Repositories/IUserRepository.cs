using System.Threading.Tasks;
using DotifyV2.Application.DTOs.Persistence;

namespace DotifyV2.Application.Repositories
{
	public interface IUserRepository
	{
		Task<UserDataDto> GetAsync(int id);
		Task<UserDataDto> GetUserByPlaylistIdAsync(int playlistId);
		Task<UserDataDto> GetUserByUsernameAsync(string username);
		Task<UserDataDto> GetUserByApiTokenAsync(string apiToken);
	}
}
