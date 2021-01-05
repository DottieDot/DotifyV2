using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DotifyV2.Presentation.Models
{
    public class CreateArtistRequest
    {
        [JsonPropertyName("name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
