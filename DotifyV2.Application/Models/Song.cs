using System.Threading.Tasks;
using DotifyV2.Application.Models.Interfaces;
using DotifyV2.Application.DTOs;
using DotifyV2.Application.Collections.Interfaces;

namespace DotifyV2.Application.Models
{
    public class Song : ISong
    {
        readonly IAlbumCollection _albumCollection;
        readonly int _albumId;

        public Song(SongDataDto dto, IAlbumCollection albumCollection)
        {
            Id = dto.Id;
            Name = dto.Name;
            Duration = dto.Duration;
            FileName = dto.FileName;

            _albumId = dto.AlbumId;

            _albumCollection = albumCollection;
        }

        public int Id { get; }

        public string Name { get; }

        public int Duration { get; }

        public string FileName { get; }

        public Task<IAlbum> GetAlbumAsync()
            => _albumCollection.GetAlbumByIdAsync(_albumId);
    }
}
