using System.Text.Json.Serialization;

namespace DotifyV2.Presentation.Models
{
	public class LoginRequestBody
	{
		[JsonPropertyName("username")]
		public string Username { get; set; }

		[JsonPropertyName("password")]
		public string Password { get; set; }
	}
}
