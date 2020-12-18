using System.Threading.Tasks;

namespace DotifyV2.Application.Models.Interfaces
{
	public interface IUser
	{
		int Id { get; }
		string Username { get; }

		bool SetPassword(string password);

		/// <summary>
		/// Checks if the password is correct for the user.
		/// </summary>
		/// <param name="password"></param>
		/// <returns>The API token for the user or null if the password is incorrect.</returns>
		string VerifyPassword(string password);

		Task SaveAsync();
	}
}
