using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DotifyV2.Presentation.Models
{
    public class CreateAlbumRequest
    {
        [JsonPropertyName("name")]
        [Required(ErrorMessage = "Required.")]
        public string Name { get; set; }
    }
}
