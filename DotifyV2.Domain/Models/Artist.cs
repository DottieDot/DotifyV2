using System.Collections.Generic;

namespace DotifyV2.Domain.Models
{
	public class Artist : ArtistDescription
	{
		public IEnumerable<AlbumDescription> Albums { get; set; }
	}
}
