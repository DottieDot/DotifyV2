using System.Collections.Generic;

namespace DotifyV2.Domain.Models
{
	public class Song : SongDescription
	{
		public ArtistDescription Artist { get; set; }
		public AlbumDescription Album { get; set; }
	}
}
