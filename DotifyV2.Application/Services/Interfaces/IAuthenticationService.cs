using System.Threading.Tasks;
using DotifyV2.Application.DTOs.Presentation;

namespace DotifyV2.Application.Services.Interfaces
{
	public interface IAuthenticationService
	{
		Task<AuthenticationResultDto> AuthenticateAsync(string username, string password);

		Task<WrappedDto<int?>> GetUserIdFromApiTokenAsync(string apiToken);
	}
}
