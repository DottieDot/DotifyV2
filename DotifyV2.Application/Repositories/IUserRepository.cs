using System.Threading.Tasks;
using DotifyV2.Application.DTOs;

namespace DotifyV2.Application.Repositories
{
	public interface IUserRepository
	{
		Task<UserDataDto> CreateUserAsync(NewUserDataDto user);
		Task<UserDataDto> GetUserByIdAsync(int id);
		Task<UserDataDto> GetUserByUsernameAsync(string username);
		Task<UserDataDto> GetUserByApiTokenAsync(string apiToken);
	}
}
