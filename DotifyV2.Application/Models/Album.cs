using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Application.Models.Interfaces;
using DotifyV2.Application.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DotifyV2.Application.Models
{
    public class Album : IAlbum
    {
        readonly IArtistCollection _artistCollection;
        readonly ISongCollection _songCollection;
        readonly int _artistId;

        public Album(AlbumDataDto dto, IArtistCollection artistCollection, ISongCollection songCollection)
        {
            Id = dto.ArtistId;
            Name = dto.Name;
            CoverArt = dto.CoverArt;

            _artistId = dto.ArtistId;

            _artistCollection = artistCollection;
            _songCollection = songCollection;
        }

        public int Id { get; }
        public string Name { get; }
        public string CoverArt { get; }

        public Task<IArtist> GetArtistAsync()
            => _artistCollection.GetArtistByIdAsync(_artistId);

        public Task<IEnumerable<ISong>> GetSongsAsync()
            => _songCollection.GetSongsByAlbumIdAsync(Id);
    }
}
