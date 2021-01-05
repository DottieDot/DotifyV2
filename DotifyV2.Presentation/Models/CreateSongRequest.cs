using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DotifyV2.Presentation.Models
{
    public class CreateSongRequest
    {
        [JsonPropertyName("album_id")]
        [Required(ErrorMessage = "Album id is sequired.")]
        public int AlbumId { get; set; }

        [JsonPropertyName("name")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [JsonPropertyName("duration")]
        [Required(ErrorMessage = "Duration is required")]
        public int Duration { get; set; }
    }
}
