using System.Collections.Generic;
using System.Threading.Tasks;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Application.DTOs;
using DotifyV2.Application.Models.Interfaces;

namespace DotifyV2.Application.Models
{
    public class Artist : IArtist
    {
        readonly IAlbumCollection _albumCollection;

        public Artist(ArtistDataDto dto, IAlbumCollection albumCollection)
        {
            _albumCollection = albumCollection;

            Id = dto.Id;
            Name = dto.Name;
            Picture = dto.Picture;
        }

        public int Id { get; }
        public string Name { get; }
        public string Picture { get; }

        public Task<IEnumerable<IAlbum>> GetAlbumsAsync()
            => _albumCollection.GetAlbumsByArtistIdAsync(Id);
    }
}
