using DotifyV2.Application.Repositories;
using System.Threading.Tasks;
using SqlKata.Execution;
using DotifyV2.Application.DTOs;
using DotifyV2.Persistence.Tables;
using DotifyV2.Common;
using System.Linq;
using System;

namespace DotifyV2.Persistence.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly QueryFactory _db;
		
		private UserDataDto UserDataDtoFromUserTableRow(UserTableRow row)
		{
			return new UserDataDto
			{
				Id = row.id,
				Username = row.username,
				ApiToken = row.api_token,
				Password = row.password,
			};
		}

		public UserRepository(QueryFactory db)
		{
			_db = db;
		}

		public async Task<UserDataDto> CreateUserAsync(NewUserDataDto user)
		{
			try
			{
				var id = await _db.Query("users")
					.InsertGetIdAsync<int>(user);

				return new UserDataDto
				{
					Id = id,
					Username = user.Username,
					Password = user.Password,
					ApiToken = user.ApiToken,
				};
			}
			catch (Exception)
			{
				return null;
			}
		}

		public async Task<UserDataDto> GetUserByIdAsync(int id)
		{
			var row = await _db.Query("users")
				.Select(typeof(UserTableRow).GetFieldNames().ToArray())
				.Where("id", id)
				.FirstOrDefaultAsync<UserTableRow>();

			return row != null ? UserDataDtoFromUserTableRow(row) : null;
		}

		public async Task<UserDataDto> GetUserByApiTokenAsync(string apiToken)
		{
			var row = await _db.Query("users")
				.Select(typeof(UserTableRow).GetFieldNames().ToArray())
				.Where("api_token", apiToken)
				.FirstOrDefaultAsync<UserTableRow>();

			return row != null ? UserDataDtoFromUserTableRow(row) : null;
		}

		public Task<UserDataDto> GetUserByPlaylistIdAsync(int playlistId)
		{
			throw new System.NotImplementedException();
		}

		public async Task<UserDataDto> GetUserByUsernameAsync(string username)
		{
			var row = await _db.Query("users")
				.Select(typeof(UserTableRow).GetFieldNames().ToArray())
				.Where("username", username)
				.FirstOrDefaultAsync<UserTableRow>();

			return row != null ? UserDataDtoFromUserTableRow(row) : null;
		}
	}
}
