using System;
using System.Text.Json.Serialization;

namespace DotifyV2.Presentation.Models
{
	[Serializable]
	public class LoginResponse
	{
		[JsonPropertyName("api_token")]
		public string ApiToken { get; set; }
	}
}
