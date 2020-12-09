using System.Security.Principal;
using DotifyV2.Application.Models.Interfaces;

namespace DotifyV2.Presentation.Identities
{
	public class BearerTokenUserIdentity : IIdentity
	{
		public BearerTokenUserIdentity(IUser user)
		{
			User = user;
		}

		public IUser User { get; private set; }

		public string AuthenticationType => "Bearer token";

		public bool IsAuthenticated => User != null;

		public string Name => User.Username;
	}
}
