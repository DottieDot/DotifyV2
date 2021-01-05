using System;
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

        public Task<IEnumerable<int>> GetLikedArtistIdsByUserIdAsync(int userId)
            => _likesTable.GetAllByBColumn(userId);

        public async Task<ArtistDataDto> GetArtistByUserIdAsync(int userId)
        {
            var row = await _db.Query("artists")
                .Select(typeof(ArtistTableRow).GetFieldNames().ToArray())
                .Where("user_id", userId)
                .FirstOrDefaultAsync<ArtistTableRow>();

            return row?.ToArtistDataDto();
        }

        public async Task<ArtistDataDto> CreateArtistAsync(NewArtistDataDto dataDto)
        {
            try
            {
                var id = await _db.Query("artists")
                    .InsertGetIdAsync<int>(new
                    {
                        user_id = dataDto.UserId,
                        name = dataDto.Name,
                    });

                return new ArtistDataDto
                {
                    Id = id,
                    Name = dataDto.Name,
                    Picture = "",
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteArtistAsync(int artistId)
        {
            int result = await _db.Query("artists")
                 .Where("id", artistId)
                 .DeleteAsync();

            return result != 0;
        }
    }
}
