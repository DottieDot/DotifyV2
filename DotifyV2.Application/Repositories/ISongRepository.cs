﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DotifyV2.Application.DTOs;

namespace DotifyV2.Application.Repositories
{
    public interface ISongRepository
    {
        Task<IEnumerable<SongDataDto>> GetSongsFromAlbumIdAsync(int albumId);

        Task<SongDataDto> GetSongByIdAsync(int songId);

        Task<bool> AddUserLikeAsync(int songId, int userId);

        Task<bool> RemoveUserLikeAsync(int songId, int userId);

        Task<IEnumerable<int>> GetLikedSongIdsByUserIdAsync(int userId);
    }
}
