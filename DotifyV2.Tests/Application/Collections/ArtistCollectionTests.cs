using System;
using System.Linq;
using System.Threading.Tasks;
using DotifyV2.Application.Collections;
using DotifyV2.Application.DTOs;
using DotifyV2.Application.Repositories;
using DotifyV2.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DotifyV2.Tests.Application.Collections
{
    [TestClass()]
    public class ArtistCollectionTests
    {
		DependencyMapper _dependencyMapper;
		IServiceProvider _serviceProvider;

		[TestInitialize()]
		public void Initialize()
		{
			var serviceProviderMock = new Mock<IServiceProvider>();
			_serviceProvider = serviceProviderMock.Object;

			_dependencyMapper = new DependencyMapper(_serviceProvider);
		}

		[TestMethod()]
		public async Task GetArtistByIdAsyncTest_ValidId_CorrectData()
        {
			var artistRepoMock = new Mock<IArtistRepository>();
			artistRepoMock.Setup(mock => mock.GetArtistByIdAsync(1))
				.ReturnsAsync(new ArtistDataDto
				{
					Id = 1,
					Name = "Test",
					Picture = "",
				})
				.Verifiable();

			var artistCollection = new ArtistCollection(artistRepoMock.Object, _dependencyMapper);
			var artist = await artistCollection.GetArtistByIdAsync(1);

			artistRepoMock.Verify();
			Assert.AreEqual(1, artist.Id);
			Assert.AreEqual("Test", artist.Name);
			Assert.AreEqual("", artist.Picture);
		}

		[TestMethod()]
		public async Task GetArtistByIdAsyncTest_InvalidId_Null()
		{
			var artistRepoMock = new Mock<IArtistRepository>();
			artistRepoMock.Setup(mock => mock.GetArtistByIdAsync(1))
				.ReturnsAsync(null as ArtistDataDto)
				.Verifiable();

			var artistCollection = new ArtistCollection(artistRepoMock.Object, _dependencyMapper);
			var artist = await artistCollection.GetArtistByIdAsync(1);

			artistRepoMock.Verify();
			Assert.AreEqual(null, artist);
		}

		[TestMethod()]
		public async Task GetLikedSongIdsByUserIdAsync_UserIdNoLikedArtists_EmptyArray()
		{
			var artistRepoMock = new Mock<IArtistRepository>();
			artistRepoMock.Setup(mock => mock.GetLikedArtistIdsByUserIdAsync(1))
				.ReturnsAsync(new int[] { })
				.Verifiable();

			var artistCollection = new ArtistCollection(artistRepoMock.Object, _dependencyMapper);
			var likedArtists = (await artistCollection.GetLikedArtistIdsByUserIdAsync(1)).ToArray();

			artistRepoMock.Verify();
			Assert.AreEqual(0, likedArtists.Length);
		}

		[TestMethod()]
		public async Task GetLikedSongIdsByUserIdAsync_UserIdLikedArtists_CorrectData()
		{
			var artistRepoMock = new Mock<IArtistRepository>();
			artistRepoMock.Setup(mock => mock.GetLikedArtistIdsByUserIdAsync(1))
				.ReturnsAsync(new int[] { 1, 2 })
				.Verifiable();

			var artistCollection = new ArtistCollection(artistRepoMock.Object, _dependencyMapper);
			var likedArtists = (await artistCollection.GetLikedArtistIdsByUserIdAsync(1)).ToArray();

			artistRepoMock.Verify();
			Assert.AreEqual(2, likedArtists.Length);
			Assert.AreEqual(1, likedArtists[0]);
			Assert.AreEqual(2, likedArtists[1]);
		}
	}
}
