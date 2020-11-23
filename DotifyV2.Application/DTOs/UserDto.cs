using DotifyV2.Domain.Models;

namespace DotifyV2.Application.DTOs
{
	public class UserDto
	{
		public UserDto(User user)
		{
			this.Id = user.Id;
			this.Username = user.Username;
		}

		int Id { get; set; }
		string Username { get; set; }
	}
}
