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

        public AlbumRepository(QueryFactory db)
        {
            _db = db;
        }

        public async Task<IEnumerable<AlbumDataDto>> GetAlbumsByArtistId(int artistId)
        {
            var rows = await _db.Query("albums")
                .Select(typeof(AlbumTableRow).GetFieldNames().ToArray())
                .Where("artist_id", artistId)
                .GetAsync<AlbumTableRow>();

            return rows.Select(row => row.ToAlbumDataDto());
        }
    }
}
