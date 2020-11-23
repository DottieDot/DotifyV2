using System.Collections.Generic;
using System.Linq;
using DotifyV2.Domain.Models;

namespace DotifyV2.Application.DTOs
{
	public class PlaylistDto
	{
		public PlaylistDto(Playlist playlist, User user, IEnumerable<Song> songs)
		{
			this.Id = playlist.Id;
			this.Name = playlist.Name;
			this.Private = playlist.Private;
			this.User = new UserDto(user);
			this.Songs = songs.Select(song => new SongDto(song, null, null /* What 2 do?! */));
		}

		int Id { get; set; }
		string Name { get; set; }
		bool Private { get; set; }
		UserDto User { get; set; }
		IEnumerable<SongDto> Songs { get; set; }
	}
}
