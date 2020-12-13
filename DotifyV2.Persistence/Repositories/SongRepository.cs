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
        QueryFactory _db;

        public SongRepository(QueryFactory db)
        {
            _db = db;
        }

        public async Task<IEnumerable<SongDataDto>> GetSongsFromAlbumIdAsync(int albumId)
        {
            var rows = await _db.Query("songs")
                .Select(typeof(SongTableRow).GetFieldNames().ToArray())
                .Where("album_id", albumId)
                .GetAsync<SongTableRow>();

            return rows.Select(row => row.ToSongDataDto());
        }
    }
}
