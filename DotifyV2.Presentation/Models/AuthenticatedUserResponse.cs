using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DotifyV2.Application.Models.Interfaces;

namespace DotifyV2.Presentation.Models
{
    [Serializable]
    public class AuthenticatedUserResponse
    {
        public static async Task<AuthenticatedUserResponse> CreateFromUserAsync(IUser user)
        {
            return new AuthenticatedUserResponse
            {
                Id = user.Id,
                ArtistId = (await user.GetArtistAsync())?.Id,
                Username = user.Username,
                Likes = new LikedItems
                {
                    Songs = await user.GetLikedSongIdsAsync(),
                    Albums = await user.GetLikedAlbumIdsAsync(),
                    Artists = await user.GetLikedArtistIdsAsync(),
                },
            };
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("artist_id")]
        public int? ArtistId { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [Serializable]
        public class LikedItems
        {
            [JsonPropertyName("songs")]
            public IEnumerable<int> Songs { get; set; }
            [JsonPropertyName("albums")]
            public IEnumerable<int> Albums { get; set; }
            [JsonPropertyName("artists")]
            public IEnumerable<int> Artists { get; set; }
        };
        [JsonPropertyName("likes")]
        public LikedItems Likes { get;set; }
    }
}
