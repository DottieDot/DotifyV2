using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Application.Models.Interfaces;
using DotifyV2.Application.Repositories;
using DotifyV2.Application.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DotifyV2.Application.Models
{
    public class Album : IAlbum
    {
        readonly IAlbumRepository _albumRepository;
        readonly IArtistCollection _artistCollection;
        readonly ISongCollection _songCollection;
        readonly int _artistId;

        public Album(AlbumDataDto dto, IAlbumRepository albumRepository, IArtistCollection artistCollection, ISongCollection songCollection)
        {
            Id = dto.Id;
            Name = dto.Name;
            CoverArt = dto.CoverArt;

            _artistId = dto.ArtistId;

            _albumRepository = albumRepository;
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

        public Task<bool> LikeAsync(int userId)
            => _albumRepository.AddUserLikeAsync(Id, userId);

        public Task<bool> RemoveLikeAsync(int userId)
            => _albumRepository.RemoveUserLikeAsync(Id, userId);
    }
}
