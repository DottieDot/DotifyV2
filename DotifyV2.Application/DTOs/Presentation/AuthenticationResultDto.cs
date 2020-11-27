using System;
using System.Collections.Generic;
using System.Text;

namespace DotifyV2.Application.DTOs.Presentation
{
	public class AuthenticationResultDto
	{
		public bool Success { get; set; }
		public string ApiToken { get; set; }
	}
}
