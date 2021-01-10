using System;
using System.Text.Json.Serialization;
using DotifyV2.Application.Models.Interfaces;

namespace DotifyV2.Presentation.Models.Descriptions
{
    [Serializable]
    public class ArtistDescription
    {
        public ArtistDescription(IArtist artist)
        {
            Id = artist.Id;
            Name = artist.Name;
            Picture = artist.Picture;
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("picture")]
        public string Picture { get; set; }
    }
}
