using SqlKata.Compilers;
using SqlKata.Execution;
using MySql.Data.MySqlClient;
using System;

namespace DotifyV2.Persistence.Infrastructure
{
	public static class QueryFactoryFactory
	{
		public static QueryFactory CreateQueryFactory(DatabaseType type, string connectionString)
		{
			switch (type)
			{
				case DatabaseType.MySql:
					var connection = new MySqlConnection(connectionString);
					var compiler = new MySqlCompiler();
					return new QueryFactory(connection, compiler);
				default:
					throw new NotImplementedException();
			}
		}
	}
}
