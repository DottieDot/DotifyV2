using System.Threading.Tasks;
using System;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Application.Repositories;
using DotifyV2.Application.Models.Interfaces;
using DotifyV2.Application.Models;

namespace DotifyV2.Application.Collections
{
	public class UserCollection : IUserCollection
	{
		readonly IUserRepository _userRepository;
		readonly IServiceProvider _serviceProvider;

		public UserCollection(IUserRepository userRepository, IServiceProvider serviceProvider)
		{
			_userRepository = userRepository;
			_serviceProvider = serviceProvider;
			
		}

		public async Task<IUser> GetUserByIdAsync(int id)
		{
			var data = await _userRepository.GetAsync(id);
			return data != null ? new User(data) : null;
		}

		public async Task<IUser> GetUserByUsernameAsync(string username)
		{
			var data = await _userRepository.GetUserByUsernameAsync(username);
			return data != null ? new User(data) : null;
		}

		public async Task<IUser> GetUserByApiTokenAsync(string apiToken)
		{
			var data = await _userRepository.GetUserByUsernameAsync(apiToken);
			return data != null ? new User(data) : null;
		}

		public async Task<IUser> GetUserByPlaylistIdAsync(int playlistId)
		{
			var data = await _userRepository.GetUserByPlaylistIdAsync(playlistId);
			return data != null ? new User(data) : null;
		}
	}
}
