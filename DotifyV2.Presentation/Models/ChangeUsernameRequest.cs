using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DotifyV2.Presentation.Models
{
    public class ChangeUsernameRequest
    {
        [JsonPropertyName("password")]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [JsonPropertyName("username")]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }
    }
}
