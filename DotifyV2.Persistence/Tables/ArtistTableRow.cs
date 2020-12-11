using DotifyV2.Application.DTOs;

namespace DotifyV2.Persistence.Tables
{
    public class ArtistTableRow
    {
        public int id;
        public string name;
        public string picture;

        public ArtistDataDto ToArtistDataDto()
        {
            return new ArtistDataDto
            {
                Id = id,
                Name = name,
                Picture = picture
            };
        }
    }
}
