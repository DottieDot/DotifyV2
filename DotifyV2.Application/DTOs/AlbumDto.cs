using System.Collections.Generic;
using System.Linq;
using DotifyV2.Domain.Models;

namespace DotifyV2.Application.DTOs
{
	public class AlbumDto
	{
		public AlbumDto(Album album, Artist artist, IEnumerable<Song> songs)
		{
			this.Id = album.Id;
			this.Name = album.Name;
			this.CoverArt = album.CoverArt;
			this.Artist = new ArtistBriefDto(artist);
			this.Songs = songs.Select(song => new SongBriefDto(song));
		}

		int Id { get; set; }
		string Name { get; set; }
		string CoverArt { get; set; }
		ArtistBriefDto Artist { get; set; } 
		IEnumerable<SongBriefDto> Songs { get; set; }
	}
}
