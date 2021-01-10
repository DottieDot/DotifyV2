using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DotifyV2.Presentation.Models
{
    public class IndexArtistsRequest
    {
        [FromQuery(Name = "offset")]
        public int Offset { get; set; }

        [FromQuery(Name = "count")]
        public int Count { get; set; }
    }
}
