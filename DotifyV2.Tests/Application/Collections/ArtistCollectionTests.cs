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
			// Arrange
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

			// Act
			var artist = await artistCollection.GetArtistByIdAsync(1);

			// Assert
			artistRepoMock.Verify();
			Assert.AreEqual(1, artist.Id);
			Assert.AreEqual("Test", artist.Name);
			Assert.AreEqual("", artist.Picture);
		}

		[TestMethod()]
		public async Task GetArtistByIdAsyncTest_InvalidId_Null()
		{
			// Arrange
			var artistRepoMock = new Mock<IArtistRepository>();
			artistRepoMock.Setup(mock => mock.GetArtistByIdAsync(1))
				.ReturnsAsync(null as ArtistDataDto)
				.Verifiable();

			var artistCollection = new ArtistCollection(artistRepoMock.Object, _dependencyMapper);

			// Act
			var artist = await artistCollection.GetArtistByIdAsync(1);

			// Assert
			artistRepoMock.Verify();
			Assert.AreEqual(null, artist);
		}

		[TestMethod()]
		public async Task GetLikedSongIdsByUserIdAsync_UserIdNoLikedArtists_EmptyArray()
		{
			// Arrange
			var artistRepoMock = new Mock<IArtistRepository>();
			artistRepoMock.Setup(mock => mock.GetLikedArtistIdsByUserIdAsync(1))
				.ReturnsAsync(new int[] { })
				.Verifiable();

			var artistCollection = new ArtistCollection(artistRepoMock.Object, _dependencyMapper);

			// Act
			var likedArtists = (await artistCollection.GetLikedArtistIdsByUserIdAsync(1)).ToArray();

			// Assert
			artistRepoMock.Verify();
			Assert.AreEqual(0, likedArtists.Length);
		}

		[TestMethod()]
		public async Task GetLikedSongIdsByUserIdAsync_UserIdLikedArtists_CorrectData()
		{
			// Arrange
			var artistRepoMock = new Mock<IArtistRepository>();
			artistRepoMock.Setup(mock => mock.GetLikedArtistIdsByUserIdAsync(1))
				.ReturnsAsync(new int[] { 1, 2 })
				.Verifiable();

			var artistCollection = new ArtistCollection(artistRepoMock.Object, _dependencyMapper);

			// Act
			var likedArtists = (await artistCollection.GetLikedArtistIdsByUserIdAsync(1)).ToArray();

			// Assert
			artistRepoMock.Verify();
			Assert.AreEqual(2, likedArtists.Length);
			Assert.AreEqual(1, likedArtists[0]);
			Assert.AreEqual(2, likedArtists[1]);
		}

		[TestMethod()]
		public async Task GetArtistByUserIdAsyncTest_ValidUserId_CorrectData()
		{
			// Arrange
			var artistRepoMock = new Mock<IArtistRepository>();
			artistRepoMock.Setup(mock => mock.GetArtistByUserIdAsync(1))
				.ReturnsAsync(new ArtistDataDto
				{
					Id = 1,
					Name = "Test",
					Picture = "",
				})
				.Verifiable();

			var artistCollection = new ArtistCollection(artistRepoMock.Object, _dependencyMapper);

			// Act
			var artist = await artistCollection.GetArtistByUserIdAsync(1);

			// Assert
			artistRepoMock.Verify();
			Assert.AreEqual(1, artist.Id);
			Assert.AreEqual("Test", artist.Name);
			Assert.AreEqual("", artist.Picture);
		}

		[TestMethod()]
		public async Task GetArtistByUserIdAsyncTest_InvalidUserId_Null()
		{
			// Arrange
			var artistRepoMock = new Mock<IArtistRepository>();
			artistRepoMock.Setup(mock => mock.GetArtistByUserIdAsync(1))
				.ReturnsAsync(null as ArtistDataDto)
				.Verifiable();

			var artistCollection = new ArtistCollection(artistRepoMock.Object, _dependencyMapper);

			// Act
			var artist = await artistCollection.GetArtistByUserIdAsync(1);

			// Assert
			artistRepoMock.Verify();
			Assert.AreEqual(null, artist);
		}

		[TestMethod()]
		public async Task GetArtistBySongIdAsyncTest_ValidSongId_CorrectData()
		{
			// Arrange
			var artistRepoMock = new Mock<IArtistRepository>();
			artistRepoMock.Setup(mock => mock.GetArtistBySongIdAsync(1))
				.ReturnsAsync(new ArtistDataDto
				{
					Id = 1,
					Name = "Test",
					Picture = "",
				})
				.Verifiable();

			var artistCollection = new ArtistCollection(artistRepoMock.Object, _dependencyMapper);

			// Act
			var artist = await artistCollection.GetArtistBySongIdAsync(1);

			// Assert
			artistRepoMock.Verify();
			Assert.AreEqual(1, artist.Id);
			Assert.AreEqual("Test", artist.Name);
			Assert.AreEqual("", artist.Picture);
		}

		[TestMethod()]
		public async Task GetArtistBySongIdAsyncTest_InvalidSongId_Null()
		{
			// Arrange
			var artistRepoMock = new Mock<IArtistRepository>();
			artistRepoMock.Setup(mock => mock.GetArtistBySongIdAsync(1))
				.ReturnsAsync(null as ArtistDataDto)
				.Verifiable();

			var artistCollection = new ArtistCollection(artistRepoMock.Object, _dependencyMapper);

			// Act
			var artist = await artistCollection.GetArtistBySongIdAsync(1);

			// Assert
			artistRepoMock.Verify();
			Assert.AreEqual(null, artist);
		}

		[TestMethod()]
		public async Task CreateArtistAsyncTest()
		{
			// Arrange
			var artistRepoMock = new Mock<IArtistRepository>();
			artistRepoMock.Setup(mock => mock.CreateArtistAsync(It.Is((NewArtistDataDto dataDto) => (
					dataDto.UserId == 1 &&
					dataDto.Name == "Test"
				))))
				.ReturnsAsync(new ArtistDataDto
				{
					Id = 1,
					Name = "Test",
					Picture = "",
				})
				.Verifiable();

			var artistCollection = new ArtistCollection(artistRepoMock.Object, _dependencyMapper);

			// Act
			var artist = await artistCollection.CreateArtistAsync(1, "Test");

			// Assert
			artistRepoMock.Verify();
			Assert.AreEqual(1, artist.Id);
			Assert.AreEqual("Test", artist.Name);
			Assert.AreEqual("", artist.Picture);
		}

		[TestMethod()]
		public async Task GetAllAlbumsAsyncTest_LessThanCount_AllAvailableData()
		{
			// Arrange
			ArtistDataDto[] result =
			{
				new ArtistDataDto
				{
					Id = 1,
					Name = "Test",
					Picture = "",
				},
				new ArtistDataDto
				{
					Id = 2,
					Name = "Test 2",
					Picture = "test2.mp3",
				},
			};
			var artitRepoMock = new Mock<IArtistRepository>();
			artitRepoMock.Setup(mock => mock.GetAllArtistsAsync(0, 4))
				.ReturnsAsync(result)
				.Verifiable();

			var albumCollection = new ArtistCollection(artitRepoMock.Object, _dependencyMapper);

			// Act
			var artists = (await albumCollection.GetAllArtistsAsync(0, 4)).ToArray();

			// Assert
			artitRepoMock.Verify();
			Assert.AreEqual(2, artists.Length);
			for (int i = 0; i < 2; ++i)
			{
				Assert.AreEqual(result[i].Id, artists[i].Id);
				Assert.AreEqual(result[i].Name, artists[i].Name);
				Assert.AreEqual(result[i].Picture, artists[i].Picture);
			}
		}

		[TestMethod()]
		public async Task GetAllAlbumsAsyncTest_MoreThanCount_MultipleSections()
		{
			// Arrange
			ArtistDataDto[] result =
			{
				new ArtistDataDto
				{
					Id = 1,
					Name = "Test",
					Picture = "",
				},
				new ArtistDataDto
				{
					Id = 2,
					Name = "Test 2",
					Picture = "test2.mp3",
				},
			};
			var artistRepoMock = new Mock<IArtistRepository>();
			artistRepoMock.Setup(mock => mock.GetAllArtistsAsync(0, 1))
				.ReturnsAsync(new[] { result[0] })
				.Verifiable();
			artistRepoMock.Setup(mock => mock.GetAllArtistsAsync(1, 1))
				.ReturnsAsync(new[] { result[1] })
				.Verifiable();

			var albumCollection = new ArtistCollection(artistRepoMock.Object, _dependencyMapper);

			// Act
			var section1 = (await albumCollection.GetAllArtistsAsync(0, 1)).ToArray();
			var section2 = (await albumCollection.GetAllArtistsAsync(1, 1)).ToArray();

			// Assert
			artistRepoMock.Verify();
			Assert.AreEqual(1, section1.Length);
			Assert.AreEqual(1, section2.Length);
			Assert.AreEqual(1, section1[0].Id);
			Assert.AreEqual(2, section2[0].Id);
		}

		[TestMethod()]
		public async Task GetAllAlbumsAsyncTest_NoAlbums_EmptyArray()
		{
			// Arrange
			var artistRepoMock = new Mock<IArtistRepository>();
			artistRepoMock.Setup(mock => mock.GetAllArtistsAsync(0, 4))
				.ReturnsAsync(new ArtistDataDto[] { })
				.Verifiable();

			var albumCollection = new ArtistCollection(artistRepoMock.Object, _dependencyMapper);

			// Act
			var albums = (await albumCollection.GetAllArtistsAsync(0, 4)).ToArray();

			// Assert
			artistRepoMock.Verify();
			Assert.AreEqual(0, albums.Length);
		}
	}
}
