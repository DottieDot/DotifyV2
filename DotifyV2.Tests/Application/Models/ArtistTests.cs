using System.Threading.Tasks;
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
    public class ArtistTests
    {
        [TestMethod()]
        public async Task GetAlbumsAsyncTest()
        {
            // Arrange
            var result = new AlbumDataDto
            {
                Id = 1,
                ArtistId = 1,
                Name = "Test",
                CoverArt = ""
            };

            var albumCollectionMock = new Mock<IAlbumCollection>();
            albumCollectionMock
                .Setup(mock => mock.GetAlbumsByArtistIdAsync(1))
                .ReturnsAsync(new[] { new Album(result, null, null, null) })
                .Verifiable();

            var artist = new Artist(new ArtistDataDto
            {
                Id = 1,
                Name = "Test",
                Picture = "",
            }, albumCollectionMock.Object, null);

            // Act
            var albums = (await artist.GetAlbumsAsync()).ToArray();

            // Assert
            albumCollectionMock.Verify();
            Assert.AreEqual(1, albums.Length);
            Assert.AreEqual(1, albums[0].Id);
        }

        [TestMethod()]
        public async Task LikeAsyncTest()
        {
            // Arrange
            var artistRepoMock = new Mock<IArtistRepository>();
            artistRepoMock
                .Setup(mock => mock.AddUserLikeAsync(1, 1))
                .ReturnsAsync(true)
                .Verifiable();

            var artist = new Artist(new ArtistDataDto
            {
                Id = 1,
                Name = "Test",
                Picture = "",
            }, null, artistRepoMock.Object);

            // Act
            var success = await artist.LikeAsync(1);

            // Assert
            artistRepoMock.Verify();
            Assert.AreEqual(true, success);
        }

        [TestMethod()]
        public async Task RemoveLikeAsyncTest()
        {
            // Arrange
            var artistRepoMock = new Mock<IArtistRepository>();
            artistRepoMock
                .Setup(mock => mock.RemoveUserLikeAsync(1, 1))
                .ReturnsAsync(true)
                .Verifiable();

            var artist = new Artist(new ArtistDataDto
            {
                Id = 1,
                Name = "Test",
                Picture = "",
            }, null, artistRepoMock.Object);

            // Act
            var success = await artist.RemoveLikeAsync(1);

            // Assert
            artistRepoMock.Verify();
            Assert.AreEqual(true, success);
        }
    }
}
