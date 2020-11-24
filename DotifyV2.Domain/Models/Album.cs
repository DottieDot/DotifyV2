using System.Collections.Generic;

namespace DotifyV2.Domain.Models
{
	public class Album : AlbumDescription
	{
		public Artist Artist { get; set; }
		public IEnumerable<SongDescription> Songs { get; set; }
	}
}
