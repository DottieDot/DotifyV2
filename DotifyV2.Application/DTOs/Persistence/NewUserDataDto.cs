using System;
using System.Collections.Generic;
using System.Text;

namespace DotifyV2.Application.DTOs.Persistence
{
	public class NewUserDataDto
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string ApiToken { get; set; }
	}
}
