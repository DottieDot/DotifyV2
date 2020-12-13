using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DotifyV2.Application.Models.Interfaces;
using DotifyV2.Presentation.Models.Descriptions;

namespace DotifyV2.Presentation.Models
{
    [Serializable]
    public class AlbumResponse
    {
        public static async Task<AlbumResponse> CreateFromAlbumAsync(IAlbum album)
        {
            var artist = await album.GetArtistAsync();
            var songs = await album.GetSongsAsync();
            return new AlbumResponse
            {
                Id = album.Id,
                Name = album.Name,
                CoverArt = album.CoverArt,
                Artist = new ArtistDescription(artist),
                Songs = songs.Select(song => new SongDescription(song)),
            };
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("cover_art")]
        public string CoverArt { get; set; }

        [JsonPropertyName("artist")]
        public ArtistDescription Artist { get; set; }

        [JsonPropertyName("songs")]
        public IEnumerable<SongDescription> Songs { get; set; }
    }
}
