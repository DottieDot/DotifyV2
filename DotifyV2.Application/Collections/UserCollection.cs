using System.Threading.Tasks;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Application.DTOs;
using DotifyV2.Application.Models;
using DotifyV2.Application.Models.Interfaces;
using DotifyV2.Application.Repositories;
using DotifyV2.Common;

namespace DotifyV2.Application.Collections
{
    public class UserCollection : IUserCollection
	{
		readonly IUserRepository _userRepository;
		readonly DependencyMapper _dependencyMapper;

		public UserCollection(IUserRepository userRepository, DependencyMapper dependencyMapper)
		{
			_userRepository = userRepository;
			_dependencyMapper = dependencyMapper;
			
		}

		public async Task<IUser> GetUserByIdAsync(int id)
		{
			var data = await _userRepository.GetUserByIdAsync(id);
			return data != null ? _dependencyMapper.Construct<User>(data) : null;
		}

		public async Task<IUser> GetUserByUsernameAsync(string username)
		{
			var data = await _userRepository.GetUserByUsernameAsync(username);
			return data != null ? _dependencyMapper.Construct<User>(data) : null;
		}

		public async Task<IUser> GetUserByApiTokenAsync(string apiToken)
		{
			var data = await _userRepository.GetUserByUsernameAsync(apiToken);
			return data != null ? _dependencyMapper.Construct<User>(data) : null;
		}

		public async Task<IUser> GetUserByPlaylistIdAsync(int playlistId)
		{
			var data = await _userRepository.GetUserByPlaylistIdAsync(playlistId);
			return data != null ? _dependencyMapper.Construct<User>(data) : null;
		}

        public async Task<IUser> CreateUserAsync(string username, string password)
        {
			var newUserData = new NewUserDataDto
			{
				Username = username,
				Password = password,
				ApiToken = Security.RandomCryptographicString(255)
			};
			var userData = await _userRepository.CreateUserAsync(newUserData);
			return userData != null ? _dependencyMapper.Construct<User>(userData) : null;
        }
    }
}
