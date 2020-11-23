using System;
using System.Collections.Generic;
using System.Text;

namespace DotifyV2.Domain.Models
{
	public class Playlist
	{
		int Id { get; set; }
		string Name { get; set; }
		bool Public { get; set; }
	}
}
