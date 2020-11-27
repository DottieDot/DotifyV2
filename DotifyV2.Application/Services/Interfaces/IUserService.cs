using DotifyV2.Application.DTOs.Presentation;
using System.Threading.Tasks;

namespace DotifyV2.Application.Services.Interfaces
{
	public interface IUserService
	{
		Task<UserDescriptionDto> GetUser(int id);
	}
}
