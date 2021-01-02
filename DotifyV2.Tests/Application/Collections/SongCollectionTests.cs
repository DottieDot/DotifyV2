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
    public class SongCollectionTests
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
		public async Task GetSongsByAlbumIdAsyncTest_ValidId_OneSong()
        {
			SongDataDto[] result =
			{
				new SongDataDto
				{
					Id = 1,
					Name = "Test",
					FileName = "test.mp3",
					Duration = 1337
				},
            };
			var songRepoMock = new Mock<ISongRepository>();
			songRepoMock.Setup(userRepo => userRepo.GetSongsByAlbumId(1))
				.ReturnsAsync(result)
				.Verifiable();

			var songCollection = new SongCollection(songRepoMock.Object, _dependencyMapper);
			var songs = (await songCollection.GetSongsByAlbumIdAsync(1)).ToArray();

			songRepoMock.Verify();
			Assert.AreEqual(1, songs.Length);
			Assert.AreEqual(1, songs[0].Id);
			Assert.AreEqual("Test", songs[0].Name);
			Assert.AreEqual("test.mp3", songs[0].FileName);
			Assert.AreEqual(1337, songs[0].Duration);
		}

		[TestMethod()]
		public async Task GetSongsByAlbumIdAsyncTest_ValidId_MultipleSongs()
		{
			SongDataDto[] result =
			{
				new SongDataDto
				{
					Id = 1,
					Name = "Test",
					FileName = "test.mp3",
					Duration = 1337
				},
				new SongDataDto
				{
					Id = 2,
					Name = "Test 2",
					FileName = "test2.mp3",
					Duration = 420
				},
			};
			var songRepoMock = new Mock<ISongRepository>();
			songRepoMock.Setup(userRepo => userRepo.GetSongsByAlbumId(1))
				.ReturnsAsync(result)
				.Verifiable();

			var songCollection = new SongCollection(songRepoMock.Object, _dependencyMapper);
			var songs = (await songCollection.GetSongsByAlbumIdAsync(1)).ToArray();

			songRepoMock.Verify();
			Assert.AreEqual(2, songs.Length);
			for (int i = 0; i < 2; ++i)
            {
				Assert.AreEqual(result[i].Id, songs[i].Id);
				Assert.AreEqual(result[i].Name, songs[i].Name);
				Assert.AreEqual(result[i].FileName, songs[i].FileName);
				Assert.AreEqual(result[i].Duration, songs[i].Duration);

				++i;
            }
		}

		[TestMethod()]
		public async Task GetSongsByAlbumIdAsyncTest_InvalidId_EmptyArray()
        {
			var songRepoMock = new Mock<ISongRepository>();
			songRepoMock.Setup(mock => mock.GetSongsByAlbumId(1))
				.ReturnsAsync(new SongDataDto[] { })
				.Verifiable();

			var songCollection = new SongCollection(songRepoMock.Object, _dependencyMapper);
			var songs = (await songCollection.GetSongsByAlbumIdAsync(1)).ToArray();

			songRepoMock.Verify();
			Assert.AreEqual(0, songs.Length);
		}

		[TestMethod()]
		public async Task GetSongByIdAsyncTest_ValidId_CorrectData()
        {
			var songRepoMock = new Mock<ISongRepository>();
			songRepoMock.Setup(mock => mock.GetSongByIdAsync(1))
				.ReturnsAsync(new SongDataDto
				{
					Id = 1,
					Name = "Test",
					FileName = "test.mp3",
					Duration = 1337
				})
				.Verifiable();

			var songCollection = new SongCollection(songRepoMock.Object, _dependencyMapper);
			var song = await songCollection.GetSongByIdAsync(1);

			songRepoMock.Verify();
			Assert.AreEqual(1, song.Id);
			Assert.AreEqual("Test", song.Name);
			Assert.AreEqual("test.mp3", song.FileName);
			Assert.AreEqual(1337, song.Duration);
		}

		[TestMethod()]
		public async Task GetSongByIdAsyncTest_InvalidId_Null()
		{
			var songRepoMock = new Mock<ISongRepository>();
			songRepoMock.Setup(mock => mock.GetSongByIdAsync(1))
				.ReturnsAsync(null as SongDataDto)
				.Verifiable();

			var songCollection = new SongCollection(songRepoMock.Object, _dependencyMapper);
			var song = await songCollection.GetSongByIdAsync(1);

			songRepoMock.Verify();
			Assert.AreEqual(null, song);
		}

		[TestMethod()]
		public async Task GetLikedSongIdsByUserIdAsync_UserIdNoLikedSongs_EmptyArray()
        {
			var songRepoMock = new Mock<ISongRepository>();
			songRepoMock.Setup(mock => mock.GetLikedSongIdsByUserIdAsync(1))
				.ReturnsAsync(new int[] { })
				.Verifiable();

			var songCollection = new SongCollection(songRepoMock.Object, _dependencyMapper);
			var likedSongs = (await songCollection.GetLikedSongIdsByUserIdAsync(1)).ToArray();

			songRepoMock.Verify();
			Assert.AreEqual(0, likedSongs.Length);
		}

		[TestMethod()]
		public async Task GetLikedSongIdsByUserIdAsync_UserIdLikedSongs_CorrectData()
		{
			var songRepoMock = new Mock<ISongRepository>();
			songRepoMock.Setup(mock => mock.GetLikedSongIdsByUserIdAsync(1))
				.ReturnsAsync(new int[] { 1, 2 })
				.Verifiable();

			var songCollection = new SongCollection(songRepoMock.Object, _dependencyMapper);
			var likedSongs = (await songCollection.GetLikedSongIdsByUserIdAsync(1)).ToArray();

			songRepoMock.Verify();
			Assert.AreEqual(2, likedSongs.Length);
			Assert.AreEqual(1, likedSongs[0]);
			Assert.AreEqual(2, likedSongs[1]);
		}
	}
}
