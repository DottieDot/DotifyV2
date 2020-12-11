using System;
using System.Text.Json.Serialization;
using DotifyV2.Application.Models.Interfaces;

namespace DotifyV2.Presentation.Models.Descriptions
{
    [Serializable]
    public class AlbumDescription
    {
        public AlbumDescription(IAlbum album)
        {
            Id = album.Id;
            Name = album.Name;
            CoverArt = album.CoverArt;
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("cover_art")]
        public string CoverArt { get; set; }
    }
}
