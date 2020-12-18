using System.Threading.Tasks;
using DotifyV2.Application.Models.Interfaces;

namespace DotifyV2.Application.Collections.Interfaces
{
	public interface IUserCollection
	{
		public Task<IUser> CreateUserAsync(string username, string password);

		public Task<IUser> GetUserByIdAsync(int id);

		public Task<IUser> GetUserByUsernameAsync(string username);

		public Task<IUser> GetUserByApiTokenAsync(string apiToken);
	}
}
