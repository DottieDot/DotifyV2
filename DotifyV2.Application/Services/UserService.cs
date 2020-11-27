using DotifyV2.Application.Services.Interfaces;
using System.Threading.Tasks;
using DotifyV2.Application.Repositories;
using DotifyV2.Application.DTOs.Presentation;
using DotifyV2.Application.Models;

namespace DotifyV2.Application.Services
{
	public class UserService : IUserService
	{
		readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<WrappedDto<UserDescriptionDto>> GetUserByIdAsync(int id)
		{
			var userData = await _userRepository.GetAsync(id);
			if (userData != null)
			{
				return new WrappedDto<UserDescriptionDto>(
					new UserDescriptionDto(new User(userData)
				));
			}
			return new WrappedDto<UserDescriptionDto>(null);
		}
	}
}
