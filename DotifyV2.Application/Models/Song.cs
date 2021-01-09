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
        readonly IArtistCollection _artistCollection;
        readonly int _albumId;

        public Song(SongDataDto dto, ISongRepository songRepository, IAlbumCollection albumCollection, IArtistCollection artistCollection)
        {
            Id = dto.Id;
            Name = dto.Name;
            Duration = dto.Duration;
            FileName = dto.FileName;

            _albumId = dto.AlbumId;

            _songRepository = songRepository;
            _albumCollection = albumCollection;
            _artistCollection = artistCollection;
        }

        public int Id { get; }

        public string Name { get; set; }

        public int Duration { get; set; }

        public string FileName { get; }

        public Task<bool> DeleteAsync()
            => _songRepository.DeleteByIdAsync(Id);

        public Task<IAlbum> GetAlbumAsync()
            => _albumCollection.GetAlbumByIdAsync(_albumId);

        public Task<IArtist> GetArtistAsync()
            => _artistCollection.GetArtistBySongIdAsync(Id);

        public Task<bool> LikeAsync(int userId)
            => _songRepository.AddUserLikeAsync(Id, userId);

        public Task<bool> RemoveLikeAsync(int userId)
            => _songRepository.RemoveUserLikeAsync(Id, userId);

        public Task<bool> SaveAsync()
            => _songRepository.UpdateByIdAsync(Id, new UpdateSongDataDto
            {
                Name = Name,
                Duration = Duration,
            });
    }
}
