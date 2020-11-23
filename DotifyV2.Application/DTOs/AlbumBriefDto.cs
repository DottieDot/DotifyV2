using DotifyV2.Domain.Models;

namespace DotifyV2.Application.DTOs
{
	public class AlbumBriefDto
	{
		public AlbumBriefDto(Album album)
		{
			this.Name = album.Name;
			this.CoverArt = album.CoverArt;
		}

		string Name { get; set; }
		string CoverArt { get; set; }
	}
}
