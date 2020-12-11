using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Application.Models.Interfaces;
using DotifyV2.Application.DTOs;
using System.Threading.Tasks;

namespace DotifyV2.Application.Models
{
    public class Album : IAlbum
    {
        readonly IArtistCollection _artistCollection;
        readonly int _artistId;

        public Album(AlbumDataDto dto, IArtistCollection artistCollection)
        {
            Id = dto.ArtistId;
            Name = dto.Name;
            CoverArt = dto.CoverArt;

            _artistCollection = artistCollection;
            _artistId = dto.ArtistId;
        }

        public int Id { get; }
        public string Name { get; }
        public string CoverArt { get; }

        public Task<IArtist> GetArtistAsync()
            => _artistCollection.GetArtistById(_artistId);
    }
}
