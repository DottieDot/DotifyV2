using System;
using System.Collections.Generic;
using System.Text;

namespace DotifyV2.Domain.Models
{
	public class User
	{
		int Id { get; set; }
		string Username { get; set; }
		string Password { get; set; }
		string ApiToken { get; set; }
	}
}
