using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DotifyV2.Presentation.Models
{
    public class ChangePasswordRequest
    {
        [JsonPropertyName("current_password")]
        [Required(ErrorMessage = "Current password is required.")]
        public string CurrentPassword { get; set; }

        [JsonPropertyName("new_password")]
        [Required(ErrorMessage = "New password is required.")]
        public string NewPassword { get; set; }
    }
}
