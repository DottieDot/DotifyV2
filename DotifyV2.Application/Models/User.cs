using DotifyV2.Application.DTOs;
using DotifyV2.Application.Models.Interfaces;

namespace DotifyV2.Application.Models
{
    public class User : IUser
	{
		string _password;
		string _apiToken;

		public int Id { get; private set; }
		public string Username { get; private set; }

		public User(UserDataDto dto)
		{
			Id = dto.Id;
			Username = dto.Username;
			_password = dto.Password;
			_apiToken = dto.ApiToken;
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
				_password = password;
				return true;
			}
			return false;
		}

		public string VerifyPassword(string password)
		{
			if (IsPasswordValid(password))
			{
				// TODO: Check hashed password
				return _password == password ? _apiToken : null;
			}
			return null;
		}

		public void Save()
		{
			throw new System.NotImplementedException();
		}
	}
}
