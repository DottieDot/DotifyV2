using System.Threading.Tasks;
using DotifyV2.Application.DTOs;
using DotifyV2.Application.Repositories;
using SqlKata.Execution;
using DotifyV2.Common;
using DotifyV2.Persistence.Tables;
using System.Linq;

namespace DotifyV2.Persistence.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        readonly QueryFactory _db;
        readonly PivotTable _likesTable;

        public ArtistRepository(QueryFactory db)
        {
            _db = db;

            _likesTable = new PivotTable(db, "artist_likes", "artist_id", "user_id");
        }

        public async Task<ArtistDataDto> GetArtistByIdAsync(int id)
        {
            var row = await _db.Query("artists")
                .Select(typeof(ArtistTableRow).GetFieldNames().ToArray())
                .Where("id", id)
                .FirstOrDefaultAsync<ArtistTableRow>();

            return row?.ToArtistDataDto();
        }

        public Task<bool> AddUserLikeAsync(int artistId, int userId)
            => _likesTable.InsertAsync(artistId, userId);

        public Task<bool> RemoveUserLikeAsync(int artistId, int userId)
            => _likesTable.DeleteAsync(artistId, userId);
    }
}
