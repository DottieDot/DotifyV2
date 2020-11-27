using DotifyV2.Application.Services.Interfaces;
using DotifyV2.Application.Repositories;
using DotifyV2.Application.Models;
using DotifyV2.Application.DTOs.Presentation;
using System.Threading.Tasks;

namespace DotifyV2.Application.Services
{
	public class AuthenticationService : IAuthenticationService
	{
		readonly IUserRepository _userRepository;

		public AuthenticationService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<AuthenticationResultDto> AuthenticateAsync(string username, string password)
		{
			var userData = await _userRepository.GetUserByUsernameAsync(username);
			if (userData != null)
			{
				var user = new User(userData);

				if (user.VerifyPassword(password))
				{
					return new AuthenticationResultDto
					{
						Success = true,
						ApiToken = user.ApiToken,
					};
				}
			}
			return new AuthenticationResultDto { Success = false };
		}

		public async Task<WrappedDto<int?>> GetUserIdFromApiTokenAsync(string apiToken)
		{
			var userData = await _userRepository.GetUserByApiTokenAsync(apiToken);
			return new WrappedDto<int?>(userData?.Id);
		}
	}
}
