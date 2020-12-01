using System.Security.Principal;
using DotifyV2.Application.DTOs.Presentation;

namespace DotifyV2.Presentation.Identities
{
	public class BearerTokenUserIdentity : IIdentity
	{
		public BearerTokenUserIdentity(UserDescriptionDto user)
		{
			User = user;
		}

		public UserDescriptionDto User { get; private set; }

		public string AuthenticationType => "Bearer token";

		public bool IsAuthenticated => User != null;

		public string Name => User.Username;
	}
}
