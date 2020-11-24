using System.Collections.Generic;

namespace DotifyV2.Domain.Models
{
	public class Playlist : PlaylistDescription
	{
		public UserDescription Owner { get; set; }
		public IEnumerable<Song> Songs { get; set; }
	}
}
