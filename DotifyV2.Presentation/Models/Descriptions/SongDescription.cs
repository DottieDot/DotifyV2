using System;
using System.Text.Json.Serialization;
using DotifyV2.Application.Models.Interfaces;

namespace DotifyV2.Presentation.Models.Descriptions
{
    [Serializable]
    public class SongDescription
    {
        public SongDescription(ISong song)
        {
            Id = song.Id;
            Name = song.Name;
            Duration = song.Duration;
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }
    }
}
