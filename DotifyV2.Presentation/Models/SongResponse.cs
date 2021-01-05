using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DotifyV2.Application.Models.Interfaces;
using DotifyV2.Presentation.Models.Descriptions;

namespace DotifyV2.Presentation.Models
{
    [Serializable]
    public class SongResponse
    {
        public static async Task<SongResponse> CreateFromSongAsync(ISong song)
        {
            return new SongResponse
            {
                Id = song.Id,
                Name = song.Name,
                Duration = song.Duration,
                FileName = song.FileName,
                Album = new AlbumDescription(await song.GetAlbumAsync()),
            };
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("file_name")]
        public string FileName { get; set; }

        [JsonPropertyName("album")]
        public AlbumDescription Album { get; set; }
    }
}
