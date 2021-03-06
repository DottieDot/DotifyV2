﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Application.Models;
using DotifyV2.Application.Models.Interfaces;
using DotifyV2.Application.Repositories;
using DotifyV2.Common;
using DotifyV2.Application.DTOs;

namespace DotifyV2.Application.Collections
{
    public class AlbumCollection : IAlbumCollection
    {
        readonly IAlbumRepository _albumRepository;
        readonly DependencyMapper _dependencyMapper;

        public AlbumCollection(IAlbumRepository albumRepository, DependencyMapper dependencyMapper)
        {
            _albumRepository = albumRepository;
            _dependencyMapper = dependencyMapper;
        }

        public async Task<IAlbum> CreateAlbumAsync(int artistId, string name)
        {
            var data = await _albumRepository.CreateAlbumAsync(new NewAlbumDataDto
            {
                ArtistId = artistId,
                Name = name,
            });
            return data != null ? _dependencyMapper.Construct<Album>(data) : null;
        }

        public async Task<IAlbum> GetAlbumByIdAsync(int albumId)
        {
            var data = await _albumRepository.GetAlbumByIdAsync(albumId);
            return data != null ? _dependencyMapper.Construct<Album>(data) : null;
        }

        public async Task<IEnumerable<IAlbum>> GetAlbumsByArtistIdAsync(int artistId)
        {
           var albums = await _albumRepository.GetAlbumsByArtistIdAsync(artistId);
           return albums.Select(data => _dependencyMapper.Construct<Album>(data));
        }

        public async Task<IEnumerable<IAlbum>> GetAllAlbumsAsync(int offset, int count)
        {
            var albums = await _albumRepository.GetAllAlbumsAsync(offset, count);
            return albums.Select(data => _dependencyMapper.Construct<Album>(data));
        }

        public Task<IEnumerable<int>> GetLikedAlbumIdsByUserIdAsync(int userId)
            => _albumRepository.GetLikedAlbumIdsByUserIdAsync(userId);
    }
}
