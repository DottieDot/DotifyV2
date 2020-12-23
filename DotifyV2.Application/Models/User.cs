using System.Collections.Generic;
using System.Threading.Tasks;
using DotifyV2.Application.DTOs;
using DotifyV2.Application.Models.Interfaces;
using DotifyV2.Application.Collections.Interfaces;

namespace DotifyV2.Application.Models
{
    public class User : IUser
	{
		string _password;
		readonly string _apiToken;

		readonly ISongCollection _songCollection;
		readonly IAlbumCollection _albumCollection;
		readonly IArtistCollection _artistCollection;

		public int Id { get; private set; }
		public string Username { get; private set; }

		public User(UserDataDto dto, ISongCollection songCollection, IAlbumCollection albumCollection, IArtistCollection artistCollection)
		{
			Id = dto.Id;
			Username = dto.Username;

			_password = dto.Password;
			_apiToken = dto.ApiToken;

			_songCollection = songCollection;
			_albumCollection = albumCollection;
			_artistCollection = artistCollection;
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

		public Task SaveAsync()
		{
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<int>> GetLikedSongIdsAsync()
			=> _songCollection.GetLikedSongIdsByUserIdAsync(Id);

		public Task<IEnumerable<int>> GetLikedAlbumIdsAsync()
			=> _albumCollection.GetLikedAlbumIdsByUserIdAsync(Id);

		public Task<IEnumerable<int>> GetLikedArtistIdsAsync()
			=> _artistCollection.GetLikedArtistIdsByUserIdAsync(Id);
    }
}
