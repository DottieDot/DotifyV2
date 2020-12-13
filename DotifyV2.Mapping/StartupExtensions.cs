using Microsoft.Extensions.DependencyInjection;
using DotifyV2.Persistence.Infrastructure;
using DotifyV2.Application.Repositories;
using DotifyV2.Persistence.Repositories;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Application.Collections;
using DotifyV2.Common;

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

			services.AddScoped<DependencyMapper>();

			#region Repositories
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IArtistRepository, ArtistRepository>();
			services.AddTransient<IAlbumRepository, AlbumRepository>();
			services.AddTransient<ISongRepository, SongRepository>();
			#endregion

			#region Services
			services.AddTransient<IUserCollection, UserCollection>();
			services.AddTransient<IArtistCollection, ArtistCollection>();
			services.AddTransient<IAlbumCollection, AlbumCollection>();
			services.AddTransient<ISongCollection, SongCollection>();
			#endregion

			return services;
		}
	}
}
