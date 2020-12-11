using DotifyV2.Application.DTOs;

namespace DotifyV2.Persistence.Tables
{
	public class UserTableRow
	{
		public int id;
		public string username;
		public string api_token;
		public string password;

		public UserDataDto ToUserDataDto()
        {
			return new UserDataDto
			{
				Id = id,
				Username = username,
				ApiToken = api_token,
				Password = password
			};
        }
	}
}
