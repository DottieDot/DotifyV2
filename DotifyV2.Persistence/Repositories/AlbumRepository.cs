using System.Threading.Tasks;
using DotifyV2.Application.DTOs;
using DotifyV2.Application.Repositories;
using SqlKata.Execution;
using DotifyV2.Common;
using DotifyV2.Persistence.Tables;
using System.Linq;
using System.Collections.Generic;

namespace DotifyV2.Persistence.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        readonly QueryFactory _db;
        readonly PivotTable _likesTable;

        public AlbumRepository(QueryFactory db)
        {
            _db = db;

            _likesTable = new PivotTable(db, "album_likes", "album_id", "user_id");
        }

        public async Task<AlbumDataDto> GetAlbumByIdAsync(int albumId)
        {
            var row = await _db.Query("albums")
                .Select(typeof(AlbumTableRow).GetFieldNames().ToArray())
                .Where("id", albumId)
                .FirstOrDefaultAsync<AlbumTableRow>();

            return row?.ToAlbumDataDto();
        }

        public async Task<IEnumerable<AlbumDataDto>> GetAlbumsByArtistIdAsync(int artistId)
        {
            var rows = await _db.Query("albums")
                .Select(typeof(AlbumTableRow).GetFieldNames().ToArray())
                .Where("artist_id", artistId)
                .GetAsync<AlbumTableRow>();

            return rows.Select(row => row.ToAlbumDataDto());
        }

        public Task<bool> AddUserLikeAsync(int albumId, int userId)
            => _likesTable.InsertAsync(albumId, userId);

        public Task<bool> RemoveUserLikeAsync(int albumId, int userId)
            => _likesTable.DeleteAsync(albumId, userId);

        public Task<IEnumerable<int>> GetLikedAlbumIdsByUserIdAsync(int userId)
            => _likesTable.GetAllByBColumn(userId);

        public Task DeleteAlbumsByArtistId(int artistId)
        {
            return _db.Query("albums")
                .Where("artist_id", artistId)
                .DeleteAsync();
        }
    }
}
