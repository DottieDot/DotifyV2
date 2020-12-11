
namespace DotifyV2.Application.Models.Interfaces
{
	public interface IUser
	{
		public int Id { get; }
		public string Username { get; }

		public bool SetPassword(string password);

		/// <summary>
		/// Checks if the password is correct for the user.
		/// </summary>
		/// <param name="password"></param>
		/// <returns>The API token for the user or null if the password is incorrect.</returns>
		public string VerifyPassword(string password);

		public void Save();
	}
}
