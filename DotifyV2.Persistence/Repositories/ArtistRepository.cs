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

        public ArtistRepository(QueryFactory db)
        {
            _db = db;
        }

        public async Task<ArtistDataDto> GetArtistByIdAsync(int id)
        {
            var row = await _db.Query("artists")
                .Select(typeof(ArtistTableRow).GetFieldNames().ToArray())
                .Where("id", id)
                .FirstOrDefaultAsync<ArtistTableRow>();

            return row?.ToArtistDataDto();
        }
    }
}
