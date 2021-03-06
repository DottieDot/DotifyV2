﻿using System.Threading.Tasks;
using System.Collections.Generic;
using DotifyV2.Application.DTOs;

namespace DotifyV2.Application.Repositories
{
    public interface IAlbumRepository
    {
        Task<bool> DeleteAlbumById(int albumId);

        Task<AlbumDataDto> CreateAlbumAsync(NewAlbumDataDto dataDto);

        Task<IEnumerable<AlbumDataDto>> GetAlbumsByArtistIdAsync(int artistId);

        Task<AlbumDataDto> GetAlbumByIdAsync(int albumId);

        Task<bool> AddUserLikeAsync(int albumId, int userId);

        Task<bool> RemoveUserLikeAsync(int albumId, int userId);

        Task<IEnumerable<int>> GetLikedAlbumIdsByUserIdAsync(int userId);

        Task<bool> UpdateAlbumByIdAsync(int albumId, UpdateAlbumDataDto dataDto);

        Task<IEnumerable<AlbumDataDto>> GetAllAlbumsAsync(int offset, int count);
    }
}
