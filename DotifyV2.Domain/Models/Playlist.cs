using System;
using System.Collections.Generic;
using System.Text;

namespace DotifyV2.Domain.Models
{
	public class Playlist
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool Private { get; set; }
	}
}
