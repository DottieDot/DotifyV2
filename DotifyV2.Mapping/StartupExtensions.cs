using Microsoft.Extensions.DependencyInjection;
using SqlKata.Execution;
using DotifyV2.Persistence.Infrastructure;
using DotifyV2.Application.Repositories;
using DotifyV2.Persistence.Repositories;
using DotifyV2.Application.Services.Interfaces;
using DotifyV2.Application.Services;

namespace DotifyV2.Mapping
{
	public static class StartupExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped(implementationFactory =>
			{
				// TODO: Load connection string from config
				return QueryFactoryFactory.CreateQueryFactory(DatabaseType.MySql, "Host=localhost;Port=3306;User=root;Password=;Database=dotify_v2;SslMode=None");
			});

			#region Repositories
			services.AddTransient<IUserRepository, UserRepository>(implementationFactory =>
			{
				var db = implementationFactory.GetService<QueryFactory>();
				return new UserRepository(db);
			});
			#endregion

			#region Services
			services.AddTransient<IUserService, UserService>(implementationFactory =>
			{
				var userRepo = implementationFactory.GetService<IUserRepository>();
				return new UserService(userRepo);
			});
			#endregion

			return services;
		}
	}
}
