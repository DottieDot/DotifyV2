using DotifyV2.Domain.Models;

namespace DotifyV2.Application.DTOs
{
	public class SongBriefDto
	{
		public SongBriefDto(Song song)
		{
			this.Id = song.Id;
			this.Name = song.Name;
			this.Duration = song.Duration;
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public int Duration { get; set; }
	}
}
