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
    public class ArtistResponse
    {
        public static async Task<ArtistResponse> CreateFromArtistAsync(IArtist artist)
        {
            var albums = await artist.GetAlbumsAsync();
            return new ArtistResponse
            {
                Id = artist.Id,
                Name = artist.Name,
                Picture = artist.Picture,
                Albums = albums.Select(album => new AlbumDescription(album))
            };
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("picture")]
        public string Picture { get; set; }

        [JsonPropertyName("albums")]
        public IEnumerable<AlbumDescription> Albums { get; set; }
    }
}
