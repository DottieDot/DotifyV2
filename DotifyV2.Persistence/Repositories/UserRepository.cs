using DotifyV2.Application.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using SqlKata.Execution;
using DotifyV2.Application.DTOs.Persistence;

namespace DotifyV2.Persistence.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly QueryFactory _db;
		
		private UserDataDto UserDataDtoFromQueryResult(dynamic row)
		{
			return new UserDataDto
			{
				Id = row["id"],
				Username = row["username"],
				ApiToken = row["api_token"],
				Password = row["password"],
			};
		}

		public UserRepository(QueryFactory db)
		{
			_db = db;
		}

		public async Task<UserDataDto> GetAsync(int id)
		{
			var row = await _db.Query("users")
				.Select("id", "username", "api_token", "password")
				.Where("id", id)
				.FirstAsync();

			return row != null ? UserDataDtoFromQueryResult(row) : null;
		}

		public Task<UserDataDto> GetUserByApiTokenAsync(string apiToken)
		{
			throw new System.NotImplementedException();
		}

		public Task<UserDataDto> GetUserByPlaylistIdAsync(int playlistId)
		{
			throw new System.NotImplementedException();
		}

		public async Task<UserDataDto> GetUserByUsernameAsync(string username)
		{
			var row = await _db.Query("users")
				.Select("id", "username", "api_token", "password")
				.Where("username", username)
				.FirstAsync();

			return row != null ? UserDataDtoFromQueryResult(row) : null;
		}
	}
}
