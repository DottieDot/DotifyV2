using System.Collections.Generic;
using System.Threading.Tasks;
using DotifyV2.Application.DTOs;
using DotifyV2.Application.Models.Interfaces;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Application.Repositories;

namespace DotifyV2.Application.Models
{
    public class User : IUser
	{
		string _password;
		readonly string _apiToken;

		readonly IUserRepository _userRepository;
		readonly ISongCollection _songCollection;
		readonly IAlbumCollection _albumCollection;
		readonly IArtistCollection _artistCollection;

		public int Id { get; }
		public string Username { get; set; }

		public User(UserDataDto dto, IUserRepository userRepository, ISongCollection songCollection, IAlbumCollection albumCollection, IArtistCollection artistCollection)
		{
			Id = dto.Id;
			Username = dto.Username;

			_password = dto.Password;
			_apiToken = dto.ApiToken;

			_userRepository = userRepository;
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

		public Task<bool> SaveAsync()
			=> _userRepository.UpdateUserByIdAsync(Id, new UpdateUserDataDto
			{
				Username = Username,
				Password = _password,
			});

		public Task<IEnumerable<int>> GetLikedSongIdsAsync()
			=> _songCollection.GetLikedSongIdsByUserIdAsync(Id);

		public Task<IEnumerable<int>> GetLikedAlbumIdsAsync()
			=> _albumCollection.GetLikedAlbumIdsByUserIdAsync(Id);

		public Task<IEnumerable<int>> GetLikedArtistIdsAsync()
			=> _artistCollection.GetLikedArtistIdsByUserIdAsync(Id);

		public Task<IArtist> GetArtistAsync()
			=> _artistCollection.GetArtistByUserIdAsync(Id);
    }
}
