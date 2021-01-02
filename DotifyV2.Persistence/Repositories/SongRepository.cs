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
    public class SongRepository : ISongRepository
    {
        readonly QueryFactory _db;
        readonly PivotTable _likesTable;

        public SongRepository(QueryFactory db)
        {
            _db = db;

            _likesTable = new PivotTable(db, "song_likes", "song_id", "user_id");
        }

        public async Task<IEnumerable<SongDataDto>> GetSongsByAlbumId(int albumId)
        {
            var rows = await _db.Query("songs")
                .Select(typeof(SongTableRow).GetFieldNames().ToArray())
                .Where("album_id", albumId)
                .GetAsync<SongTableRow>();

            return rows.Select(row => row.ToSongDataDto());
        }

        public Task<bool> AddUserLikeAsync(int songId, int userId)
            => _likesTable.InsertAsync(songId, userId);

        public Task<bool> RemoveUserLikeAsync(int songId, int userId)
            => _likesTable.DeleteAsync(songId, userId);

        public async Task<SongDataDto> GetSongByIdAsync(int songId)
        {
            var row = await _db.Query("songs")
                .Select(typeof(SongTableRow).GetFieldNames().ToArray())
                .Where("id", songId)
                .FirstAsync<SongTableRow>();

            return row?.ToSongDataDto();
        }

        public Task<IEnumerable<int>> GetLikedSongIdsByUserIdAsync(int userId)
            => _likesTable.GetAllByBColumn(userId);
    }
}
