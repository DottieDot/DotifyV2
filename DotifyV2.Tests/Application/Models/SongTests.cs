using System.Threading.Tasks;
using DotifyV2.Application.DTOs;
using DotifyV2.Application.Collections.Interfaces;
using DotifyV2.Application.Models;
using DotifyV2.Application.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DotifyV2.Tests.Application.Models
{
    [TestClass()]
    public class SongTests
    {
        [TestMethod()]
        public async Task GetAlbumAsyncTest()
        {
            // Arrange
            var result = new AlbumDataDto
            {
                Id = 1,
                Name = "",
                ArtistId = 0,
                CoverArt = "",
            };

            var albumCollectionMock = new Mock<IAlbumCollection>();
            albumCollectionMock
                .Setup(mock => mock.GetAlbumByIdAsync(1))
                .ReturnsAsync(new Album(result, null, null, null))
                .Verifiable();

            var song = new Song(new SongDataDto
            {
                Id = 1,
                AlbumId = 1,
                Name = "",
                FileName = "",
                Duration = 0,
            }, null, albumCollectionMock.Object, null);

            // Act
            var album = await song.GetAlbumAsync();

            // Assert
            albumCollectionMock.Verify();
            Assert.AreEqual(1, song.Id);
        }

        [TestMethod()]
        public async Task LikeAsyncTest()
        {
            // Arrange
            var songRepoMock = new Mock<ISongRepository>();
            songRepoMock
                .Setup(mock => mock.AddUserLikeAsync(1, 1))
                .ReturnsAsync(true)
                .Verifiable();

            var song = new Song(new SongDataDto
            {
                Id = 1,
                AlbumId = 1,
                Name = "",
                FileName = "",
                Duration = 0,
            }, songRepoMock.Object, null, null);

            // Act
            var success = await song.LikeAsync(1);

            // Assert
            songRepoMock.Verify();
            Assert.AreEqual(true, success);
        }

        [TestMethod()]
        public async Task RemoveLikeAsyncTest()
        {
            // Arrange
            var songRepoMock = new Mock<ISongRepository>();
            songRepoMock
                .Setup(mock => mock.RemoveUserLikeAsync(1, 1))
                .ReturnsAsync(true)
                .Verifiable();

            var song = new Song(new SongDataDto
            {
                Id = 1,
                AlbumId = 1,
                Name = "",
                FileName = "",
                Duration = 0,
            }, songRepoMock.Object, null, null);

            // Act
            var success = await song.RemoveLikeAsync(1);

            // Assert
            songRepoMock.Verify();
            Assert.AreEqual(true, success);
        }

        [TestMethod()]
        public async Task DeleteAsyncTest()
        {
            // Arrange
            var songRepoMock = new Mock<ISongRepository>();
            songRepoMock
                .Setup(mock => mock.DeleteByIdAsync(1))
                .ReturnsAsync(true)
                .Verifiable();

            var song = new Song(new SongDataDto
            {
                Id = 1,
                AlbumId = 1,
                Name = "",
                FileName = "",
                Duration = 0,
            }, songRepoMock.Object, null, null);

            // Act
            var success = await song.DeleteAsync();

            // Assert
            songRepoMock.Verify();
            Assert.AreEqual(true, success);
        }

        [TestMethod()]
        public async Task UpateByIdAsyncTest()
        {
            // Arrange
            var songRepoMock = new Mock<ISongRepository>();
            songRepoMock
                .Setup(mock => mock.UpdateByIdAsync(1, It.Is((UpdateSongDataDto data) => (
                    data.Name == "updated" &&
                    data.Duration == 20
                ))))
                .ReturnsAsync(true)
                .Verifiable();

            var song = new Song(new SongDataDto
            {
                Id = 1,
                AlbumId = 1,
                Name = "",
                FileName = "",
                Duration = 0,
            }, songRepoMock.Object, null, null);

            // Act
            song.Name = "updated";
            song.Duration = 20;
            var success = await song.SaveAsync();

            // Assert
            songRepoMock.Verify();
            Assert.AreEqual(true, success);
        }

        [TestMethod()]
        public async Task GetArtistAsyncTest()
        {
            // Arrange
            var result = new ArtistDataDto
            {
                Id = 1,
                Name = "",
                Picture = "",
            };

            var artistCollection = new Mock<IArtistCollection>();
            artistCollection
                .Setup(mock => mock.GetArtistBySongIdAsync(1))
                .ReturnsAsync(new Artist(result, null, null))
                .Verifiable();

            var song = new Song(new SongDataDto
            {
                Id = 1,
                AlbumId = 1,
                Name = "",
                FileName = "",
                Duration = 0,
            }, null, null, artistCollection.Object);

            // Act
            var artist = await song.GetArtistAsync();

            // Assert
            artistCollection.Verify();
            Assert.AreEqual(1, song.Id);
        }
    }
}
