using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DotifyV2.Presentation.Models
{
    [Serializable]
    public class SignUpRequest
    {
        [JsonPropertyName("username")]
        [Required(ErrorMessage = "Username is required.")]
        // [Unique(typeof(IUserCollection), "GetUserByUsernameAsync", ErrorMessage = "Username already exists")]
        public string Username { get; set; }
        
        [JsonPropertyName("password")]
        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{8,80}$", ErrorMessage = "Password is weak.")]
        public string Password { get; set; }
    }
}
