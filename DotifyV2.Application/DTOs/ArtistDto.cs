using System.Collections.Generic;
using System.Linq;
using DotifyV2.Domain.Models;

namespace DotifyV2.Application.DTOs
{
	public class ArtistDto
	{
		public ArtistDto(Artist artist, IEnumerable<Album> albums)
		{
			this.Id = artist.Id;
			this.Name = artist.Name;
			this.Picture = artist.Picture;
			this.Albums = albums.Select(album => new AlbumBriefDto(album));
		}

		int Id { get; set; }
		string Name { get; set; }
		string Picture { get; set; }
		IEnumerable<AlbumBriefDto> Albums { get; set; }
	}
}
