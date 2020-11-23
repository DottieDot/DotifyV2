using DotifyV2.Domain.Models;

namespace DotifyV2.Application.DTOs
{
	public class SongDto
	{
		public SongDto(Song song, Artist artist, Album album)
		{
			this.Id = song.Id;
			this.Name = song.Name;
			this.Duration = song.Duration;
			this.Artist = new ArtistBriefDto(artist);
			this.Album = new AlbumBriefDto(album);
		}

		int Id { get; set; }
		string Name { get; set; }
		int Duration { get; set; }
		ArtistBriefDto Artist { get; set; }
		AlbumBriefDto Album { get; set; }
	}
}
