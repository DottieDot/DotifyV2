using DotifyV2.Domain.Models;

namespace DotifyV2.Application.DTOs
{
	public class ArtistBriefDto
	{
		public ArtistBriefDto(Artist artist)
		{
			this.Id = artist.Id;
			this.Name = artist.Name;
			this.Picture = artist.Picture;
		}

		int Id { get; set; }
		string Name { get; set; }
		string Picture { get; set; }
	}
}
