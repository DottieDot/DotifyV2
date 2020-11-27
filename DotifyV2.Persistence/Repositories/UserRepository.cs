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
		
		public UserRepository(QueryFactory db)
		{
			_db = db;
		}

		public Task<UserDataDto> CreateAsync(UserDataDto model)
		{
			throw new System.NotImplementedException();
		}

		public Task<bool> DeleteAsync(int id)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<UserDataDto>> GetAllAsync()
		{
			throw new System.NotImplementedException();
		}

		public async Task<UserDataDto> GetAsync(int id)
		{
			var row = await _db.Query("users")
				.Select("id", "username", "api_token", "password")
				.Where("id", id)
				.FirstAsync();

			return new UserDataDto
			{
				Id = row["id"],
				Username = row["username"],
				ApiToken = row["api_token"],
				Password = row["password"],
			};
		}

		public Task<UserDataDto> GetWithRelationsAsync(int id)
		{
			throw new System.NotImplementedException();
		}

		public Task<UserDataDto> GetUserByApiTokenAsync(string apiToken)
		{
			throw new System.NotImplementedException();
		}

		public Task<UserDataDto> GetUserByPlaylistIdAsync(int playlistId)
		{
			throw new System.NotImplementedException();
		}

		public Task<UserDataDto> GetUserByUsernameAsync(string username)
		{
			throw new System.NotImplementedException();
		}

		public Task<bool> UpdateAsync(UserDataDto model)
		{
			throw new System.NotImplementedException();
		}
	}
}
