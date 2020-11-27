using DotifyV2.Application.Models;

namespace DotifyV2.Application.DTOs.Presentation
{
	public class UserDescriptionDto
	{
		public int Id { get; set; }
		public string Username { get; set; }

		public UserDescriptionDto(User userDescription)
		{
			this.Id = userDescription.Id;
			this.Username = userDescription.Username;
		}
	}
}
