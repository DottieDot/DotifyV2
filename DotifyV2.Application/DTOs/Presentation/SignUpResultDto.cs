
namespace DotifyV2.Application.DTOs.Presentation
{
	public class SignUpResultDto
	{
		public bool Success { get; set; }
		public UserDescriptionDto User { get; set; }
		public string ApiToken { get; set; }
	}
}
