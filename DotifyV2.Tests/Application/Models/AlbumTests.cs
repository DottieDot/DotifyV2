﻿using System.Threading.Tasks;
using System.Linq;
using DotifyV2.Application.DTOs;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Application.Models;
using DotifyV2.Application.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DotifyV2.Tests.Application.Models
{
    [TestClass()]
    public class AlbumTests
    {
        [TestMethod()]
        public async Task GetArtistAsyncTest()
        {
            // Arrange
            var artistData = new ArtistDataDto
            {
                Id = 1,
                Name = "Test",
                Picture = "",
            };

            var artistCollectionMock = new Mock<IArtistCollection>();
            artistCollectionMock
                .Setup(mock => mock.GetArtistByIdAsync(1))
                .ReturnsAsync(new Artist(artistData, null, null))
                .Verifiable();

            var album = new Album(new AlbumDataDto
            {
                Id = 1,
                ArtistId = 1,
                Name = "Test",
                CoverArt = "",
            }, null, artistCollectionMock.Object, null);

            // Act
            var artist = await album.GetArtistAsync();

            // Assert
            artistCollectionMock.Verify();
            Assert.AreEqual(1, artist.Id);
        }

        [TestMethod()]
        public async Task GetSongsAsyncTest()
        {
            // Arrange
            var result = new SongDataDto
            {
                Id = 1,
                AlbumId = 1,
                Name = "Test",
                Duration = 1337,
                FileName = "test.mp3"
            };

            var songCollectionMock = new Mock<ISongCollection>();
            songCollectionMock
                .Setup(mock => mock.GetSongsByAlbumIdAsync(1))
                .ReturnsAsync(new[] { new Song(result, null, null, null) })
                .Verifiable();

            var album = new Album(new AlbumDataDto
            {
                Id = 1,
                ArtistId = 1,
                Name = "Test",
                CoverArt = ""
            }, null, null, songCollectionMock.Object);

            // Act
            var songs = (await album.GetSongsAsync()).ToArray();

            // Assert
            songCollectionMock.Verify();
            Assert.AreEqual(1, songs.Length);
            Assert.AreEqual(1, songs[0].Id);
        }

        [TestMethod()]
        public async Task LikeAsyncTest()
        {
            // Arrange
            var albumRepoMock = new Mock<IAlbumRepository>();
            albumRepoMock
                .Setup(mock => mock.AddUserLikeAsync(1, 1))
                .ReturnsAsync(true)
                .Verifiable();

            var album = new Album(new AlbumDataDto
            {
                Id = 1,
                ArtistId = 1,
                Name = "Test",
                CoverArt = ""
            }, albumRepoMock.Object, null, null);

            // Act
            var success = await album.LikeAsync(1);

            // Assert
            albumRepoMock.Verify();
            Assert.AreEqual(true, success);
        }

        [TestMethod()]
        public async Task RemoveLikeAsyncTest()
        {
            // Arrange
            var albumRepoMock = new Mock<IAlbumRepository>();
            albumRepoMock
                .Setup(mock => mock.RemoveUserLikeAsync(1, 1))
                .ReturnsAsync(true)
                .Verifiable();

            var album = new Album(new AlbumDataDto
            {
                Id = 1,
                ArtistId = 1,
                Name = "Test",
                CoverArt = ""
            }, albumRepoMock.Object, null, null);

            // Accept
            var success = await album.RemoveLikeAsync(1);

            // Assert
            albumRepoMock.Verify();
            Assert.AreEqual(true, success);
        }
    }
}
