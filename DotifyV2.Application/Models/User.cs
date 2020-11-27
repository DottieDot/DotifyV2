using DotifyV2.Application.DTOs.Persistence;

namespace DotifyV2.Application.Models
{
	public class User
	{
		public int Id { get; private set; }
		public string Username { get; private set; }
		public string Password { get; private set; }
		public string ApiToken { get; private set; }

		public User(UserDataDto dto)
		{
			Id = dto.Id;
			Username = dto.Username;
			Password = dto.Password;
			ApiToken = dto.ApiToken;
		}

		private bool IsPasswordValid(string password)
		{
			return password.Length < 80;
		}

		public bool SetPassword(string password)
		{
			if (IsPasswordValid(password))
			{
				// TODO: Hash password
				this.Password = password;
				return true;
			}
			return false;
		}

		public bool DoesPasswordMatch(string password)
		{
			if (IsPasswordValid(password))
			{
				// TODO: Check hashed password
				return this.Password == password;
			}
			return false;
		}
	}
}
