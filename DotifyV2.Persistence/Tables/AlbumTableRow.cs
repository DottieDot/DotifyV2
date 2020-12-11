using DotifyV2.Application.DTOs;

namespace DotifyV2.Persistence.Tables
{
    public class AlbumTableRow
    {
        public int id;
        public int artist_id;
        public string name;
        public string cover_art;

        public AlbumDataDto ToAlbumDataDto()
        {
            return new AlbumDataDto
            {
                Id = id,
                ArtistId = artist_id,
                Name = name,
                CoverArt = cover_art,
            };
        }
    }
}
