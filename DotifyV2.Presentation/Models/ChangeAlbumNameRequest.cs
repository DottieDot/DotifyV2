using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DotifyV2.Presentation.Models
{
    public class ChangeAlbumNameRequest
    {
        [JsonPropertyName("name")]
        [Required(ErrorMessage = "Required.")]
        public string Name { get; set; }
    }
}
