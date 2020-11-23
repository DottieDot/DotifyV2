using DotifyV2.Domain.Models;

namespace DotifyV2.Application.DTOs
{
	public class PlaylistBriefDto
	{
		public PlaylistBriefDto(Playlist playlist)
		{
			this.Id = playlist.Id;
			this.Name = playlist.Name;
			this.Private = playlist.Private;
		}

		int Id { get; set; }
		string Name { get; set; }
		bool Private { get; set; }
	}
}
