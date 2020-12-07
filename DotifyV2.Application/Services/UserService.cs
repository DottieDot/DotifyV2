using DotifyV2.Application.Services.Interfaces;
using System.Threading.Tasks;
using DotifyV2.Application.Repositories;
using DotifyV2.Application.DTOs.Presentation;
using DotifyV2.Application.Models;
using DotifyV2.Application.DTOs.Persistence;

namespace DotifyV2.Application.Services
{
	public class UserService : IUserService
	{
		readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<WrappedDto<UserDescriptionDto>> GetUser(int id)
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

		public async Task<SignUpResultDto> SignUp(string username, string password)
		{
			var newUserData = new NewUserDataDto
			{
				Username = username,
				Password = password,
				ApiToken = ""
			};
			var userData = await _userRepository.Create(newUserData);
			if (userData != null)
			{
				return new SignUpResultDto
				{
					Success = true,
					User = new UserDescriptionDto(new User(userData)),
					ApiToken = userData.ApiToken
				};
			}
			return new SignUpResultDto { Success = false };
		}
	}
}
