using System;
using System.Collections.Generic;
using System.Text;

namespace DotifyV2.Domain.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string ApiToken { get; set; }
	}
}
