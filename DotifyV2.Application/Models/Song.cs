using System.Threading.Tasks;
using DotifyV2.Application.Models.Interfaces;
using DotifyV2.Application.DTOs;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Application.Repositories;

namespace DotifyV2.Application.Models
{
    public class Song : ISong
    {
        readonly ISongRepository _songRepository;
        readonly IAlbumCollection _albumCollection;
        readonly int _albumId;

        public Song(SongDataDto dto, ISongRepository songRepository, IAlbumCollection albumCollection)
        {
            Id = dto.Id;
            Name = dto.Name;
            Duration = dto.Duration;
            FileName = dto.FileName;

            _albumId = dto.AlbumId;

            _songRepository = songRepository;
            _albumCollection = albumCollection;
        }

        public int Id { get; }

        public string Name { get; }

        public int Duration { get; }

        public string FileName { get; }

        public Task<IAlbum> GetAlbumAsync()
            => _albumCollection.GetAlbumByIdAsync(_albumId);

        public Task<bool> LikeAsync(int userId)
            => _songRepository.AddUserLikeAsync(Id, userId);

        public Task<bool> RemoveLikeAsync(int userId)
            => _songRepository.RemoveUserLikeAsync(Id, userId);
    }
}
