
namespace DotifyV2.Domain.Models
{
	public class UserDescription
	{
		public int Id { get; private set; }
		public string Username { get; private set; }
		public string Password { get; private set; }
		public string ApiToken { get; private set; }

		private bool isPasswordValid(string password)
		{
			return password.Length < 80;
		}

		public bool SetPassword(string password)
		{
			if (isPasswordValid(password))
			{
				// TODO: Hash password
				this.Password = password;
				return true;
			}
			return false;
		}

		public bool DoesPasswordMatch(string password)
		{
			if (isPasswordValid(password))
			{
				// TODO: Check hashed password
				return this.Password == password;
			}
			return false;
		}
	}
}
