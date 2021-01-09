using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DotifyV2.Presentation.Models
{
    public class UpdateSongRequest
    {
        [JsonPropertyName("name")]
        [Required(ErrorMessage = "Required.")]
        public string Name { get; set; }

        [JsonPropertyName("duration")]
        [Required(ErrorMessage = "Required.")]
        public int Durtion { get; set; }
    }
}
