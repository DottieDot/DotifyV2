using System;
using System.Collections.Generic;
using System.Text;

namespace DotifyV2.Domain.Models
{
	public class Song
	{
		int Id { get; set; }
		string Name { get; set; }
		int Duration { get; set; }
		string FileName { get; set; }
	}
}
