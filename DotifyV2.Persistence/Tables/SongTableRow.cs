using DotifyV2.Application.DTOs;

namespace DotifyV2.Persistence.Tables
{
    public class SongTableRow
    {
        public int id;
        public int album_id;
        public string name;
        public int duration;
        public string file_name;

        public SongDataDto ToSongDataDto()
        {
            return new SongDataDto
            {
                Id = id,
                AlbumId = album_id,
                Name = name,
                Duration = duration,
                FileName = file_name,
            };
        }
    }
}
