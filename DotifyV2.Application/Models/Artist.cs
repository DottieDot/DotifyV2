using System.Collections.Generic;
using System.Threading.Tasks;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Application.DTOs;
using DotifyV2.Application.Models.Interfaces;
using DotifyV2.Application.Repositories;

namespace DotifyV2.Application.Models
{
    public class Artist : IArtist
    {
        readonly IArtistRepository _artistRepository;
        readonly IAlbumCollection _albumCollection;

        public Artist(ArtistDataDto dto, IAlbumCollection albumCollection, IArtistRepository artistRepository)
        {
            Id = dto.Id;
            Name = dto.Name;
            Picture = dto.Picture;

            _albumCollection = albumCollection;
            _artistRepository = artistRepository;
        }

        public int Id { get; }
        public string Name { get; }
        public string Picture { get; }

        public Task<IEnumerable<IAlbum>> GetAlbumsAsync()
            => _albumCollection.GetAlbumsByArtistIdAsync(Id);

        public Task<bool> LikeAsync(int userId)
            => _artistRepository.AddUserLikeAsync(Id, userId);

        public Task<bool> RemoveLikeAsync(int userId)
            => _artistRepository.RemoveUserLikeAsync(Id, userId);

        public Task<bool> DeleteAsync()
            => _artistRepository.DeleteArtistAsync(Id);

        public Task<IAlbum> CreateAlbumAsync(string name)
            => _albumCollection.CreateAlbumAsync(Id, name);
    }
}
