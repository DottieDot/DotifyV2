﻿using System;
using System.Linq;
using System.Threading.Tasks;
using DotifyV2.Application.Collections;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Application.DTOs;
using DotifyV2.Application.Repositories;
using DotifyV2.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DotifyV2.Tests.Application.Collections
{
	[TestClass()]
    public class AlbumCollectionTests
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
		public async Task GetAlbumsByArtistIdAsyncTest_ValidId_OneAlbum()
        {
			// Arrange
			AlbumDataDto[] result =
			{
				new AlbumDataDto
				{
					Id = 1,
					Name = "Test",
					CoverArt = ""
				},
			};
			var albumRepoMock = new Mock<IAlbumRepository>();
			albumRepoMock.Setup(mock => mock.GetAlbumsByArtistIdAsync(1))
				.ReturnsAsync(result)
				.Verifiable();

			var albumCollection = new AlbumCollection(albumRepoMock.Object, null, _dependencyMapper);

			// Act
			var albums = (await albumCollection.GetAlbumsByArtistIdAsync(1)).ToArray();

			// Assert
			albumRepoMock.Verify();
			Assert.AreEqual(1, albums.Length);
		}

		[TestMethod()]
		public async Task GetAlbumsByArtistIdAsyncTest_ValidId_MultipleAlbums()
        {
			// Arrange
			AlbumDataDto[] result =
			{
				new AlbumDataDto
				{
					Id = 1,
					Name = "Test",
					CoverArt = "",
				},
				new AlbumDataDto
				{
					Id = 2,
					Name = "Test 2",
					CoverArt = "test2.mp3",
				},
			};
			var albumRepoMock = new Mock<IAlbumRepository>();
			albumRepoMock.Setup(mock => mock.GetAlbumsByArtistIdAsync(1))
				.ReturnsAsync(result)
				.Verifiable();

			var albumCollection = new AlbumCollection(albumRepoMock.Object, null, _dependencyMapper);

			// Act
			var albums = (await albumCollection.GetAlbumsByArtistIdAsync(1)).ToArray();

			// Assert
			albumRepoMock.Verify();
			Assert.AreEqual(2, albums.Length);
			for (int i = 0; i < 2; ++i)
			{
				Assert.AreEqual(result[i].Id, albums[i].Id);
				Assert.AreEqual(result[i].Name, albums[i].Name);
				Assert.AreEqual(result[i].CoverArt, albums[i].CoverArt);
			}
		}

		[TestMethod()]
		public async Task GetAlbumsByArtistIdAsyncTest_InvalidId_EmptyArray()
		{
			// Arrange
			var albumRepo = new Mock<IAlbumRepository>();
			albumRepo.Setup(mock => mock.GetAlbumsByArtistIdAsync(1))
				.ReturnsAsync(new AlbumDataDto[] { })
				.Verifiable();

			var albumCollection = new AlbumCollection(albumRepo.Object, null, _dependencyMapper);

			// Act
			var albums = (await albumCollection.GetAlbumsByArtistIdAsync(1)).ToArray();

			// Assert
			albumRepo.Verify();
			Assert.AreEqual(0, albums.Length);
		}

		[TestMethod()]
		public async Task GetAlbumByIdAsyncTest_ValidId_CorrectData()
        {
			// Arrange
			var albumRepoMock = new Mock<IAlbumRepository>();
			albumRepoMock.Setup(mock => mock.GetAlbumByIdAsync(1))
				.ReturnsAsync(new AlbumDataDto
				{
					Id = 1,
					Name = "Test",
					CoverArt = "",
				})
				.Verifiable();

			var albumCollection = new AlbumCollection(albumRepoMock.Object, null, _dependencyMapper);

			// Act
			var album = await albumCollection.GetAlbumByIdAsync(1);

			// Assert
			albumRepoMock.Verify();
			Assert.AreEqual(1, album.Id);
			Assert.AreEqual("Test", album.Name);
			Assert.AreEqual("", album.CoverArt);
		}

		[TestMethod()]
		public async Task GetAlbumByIdAsyncTest_InvalidId_Null()
        {
			// Arrange
			var albumRepoMock = new Mock<IAlbumRepository>();
			albumRepoMock.Setup(mock => mock.GetAlbumByIdAsync(1))
				.ReturnsAsync(null as AlbumDataDto)
				.Verifiable();

			var albumCollection = new AlbumCollection(albumRepoMock.Object, null, _dependencyMapper);
			
			// Act
			var album = await albumCollection.GetAlbumByIdAsync(1);

			// Assert
			albumRepoMock.Verify();
			Assert.AreEqual(null, album);
		}

		[TestMethod()]
		public async Task GetLikedAlbumIdsByUserIdAsyncTest_UserIdNoLikedArtists_EmptyArray()
		{
			// Arrange
			var albumRepoMock = new Mock<IAlbumRepository>();
			albumRepoMock.Setup(mock => mock.GetLikedAlbumIdsByUserIdAsync(1))
				.ReturnsAsync(new int[] { })
				.Verifiable();

			var albumCollection = new AlbumCollection(albumRepoMock.Object, null, _dependencyMapper);

			// Act
			var likedAlbums = (await albumCollection.GetLikedAlbumIdsByUserIdAsync(1)).ToArray();

			// Assert
			albumRepoMock.Verify();
			Assert.AreEqual(0, likedAlbums.Length);
		}

		[TestMethod()]
		public async Task GetLikedAlbumIdsByUserIdAsyncTest_UserIdLikedArtists_CorrectData()
		{
			// Arrange
			var albumRepoMock = new Mock<IAlbumRepository>();
			albumRepoMock.Setup(mock => mock.GetLikedAlbumIdsByUserIdAsync(1))
				.ReturnsAsync(new int[] { 1, 2 })
				.Verifiable();

			var albumCollection = new AlbumCollection(albumRepoMock.Object, null, _dependencyMapper);

			// Act
			var likedAlbums = (await albumCollection.GetLikedAlbumIdsByUserIdAsync(1)).ToArray();

			// Assert
			albumRepoMock.Verify();
			Assert.AreEqual(2, likedAlbums.Length);
			Assert.AreEqual(1, likedAlbums[0]);
			Assert.AreEqual(2, likedAlbums[1]);
		}

		[TestMethod()]
		public async Task CreateAlbumAsyncTest()
		{
			// Arrange
			var albumRepoMock = new Mock<IAlbumRepository>();
			albumRepoMock.Setup(mock => mock.CreateAlbumAsync(It.Is((NewAlbumDataDto dataDto) => (
					dataDto.Name == "Test" &&
					dataDto.ArtistId == 1
				))))
				.ReturnsAsync(new AlbumDataDto
				{
					Id = 1,
					ArtistId = 1,
					Name = "Test",
					CoverArt = "",
				})
				.Verifiable();

			var albumCollection = new AlbumCollection(albumRepoMock.Object, null, _dependencyMapper);

			// Act
			var album = await albumCollection.CreateAlbumAsync(1, "Test");

			// Assert
			albumRepoMock.Verify();
			Assert.AreEqual(1, album.Id);
			Assert.AreEqual("Test", album.Name);
		}

		[TestMethod()]
		public async Task DeleteAlbumsByArtistIdAsyncTest()
		{
			// Arrange
			var albumRepoMock = new Mock<IAlbumRepository>();
			albumRepoMock.Setup(mock => mock.DeleteAlbumsByArtistId(1))
				.Verifiable();
			var songCollectionMock = new Mock<ISongCollection>();
			songCollectionMock.Setup(mock => mock.DeleteSongsByArtistIdAsync(1))
				.Verifiable();

			var albumCollection = new AlbumCollection(albumRepoMock.Object, songCollectionMock.Object, _dependencyMapper);

			// Act
			await albumCollection.DeleteAlbumsByArtistIdAsync(1);

			// Assert
			albumRepoMock.Verify();
			songCollectionMock.Verify();
		}
	}
}
