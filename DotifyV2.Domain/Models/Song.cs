using System;
using System.Collections.Generic;
using System.Text;

namespace DotifyV2.Domain.Models
{
	public class Song
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Duration { get; set; }
		public string FileName { get; set; }
	}
}
