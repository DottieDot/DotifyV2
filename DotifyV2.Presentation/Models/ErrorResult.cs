using System;
using System.Text.Json.Serialization;

namespace DotifyV2.Presentation.Models
{
    [Serializable]
    public class ErrorResult
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }
    }
}
