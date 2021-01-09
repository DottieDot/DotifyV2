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
    public class UserTests
    {
        [TestMethod()]
        public void SetPasswordTest_ValidPassword_True()
        {
            // Arrange
            var user = new User(new UserDataDto
            {
                Id = 1,
                Username = "",
                Password = "",
                ApiToken = "",
            }, null, null, null, null);

            // Act
            var result = user.SetPassword("test");

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void SetPasswordTest_TooLongPassword_False()
        {
            // Arrange
            var user = new User(new UserDataDto
            {
                Id = 1,
                Username = "",
                Password = "",
                ApiToken = "",
            }, null, null, null, null);

            // Act
            var result = user.SetPassword(new string('a', 81));

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public void VerifyPasswordTest_CorrectPassword_ApiToken()
        {
            // Arrange
            var user = new User(new UserDataDto
            {
                Id = 1,
                Username = "",
                Password = "test",
                ApiToken = "success",
            }, null, null, null, null);

            // Act
            var apiToken = user.VerifyPassword("test");

            // Assert
            Assert.AreEqual("success", apiToken);
        }

        [TestMethod()]
        public void VerifyPasswordTest_IncorrectPassword_Null()
        {
            // Arrange
            var user = new User(new UserDataDto
            {
                Id = 1,
                Username = "",
                Password = "test",
                ApiToken = "success",
            }, null, null, null, null);

            // Act
            var apiToken = user.VerifyPassword("hey");

            // Assert
            Assert.AreEqual(null, apiToken);
        }

        [TestMethod()]
        public void VerifyPasswordTest_InvalidPassword_Null()
        {
            // Arrange
            var user = new User(new UserDataDto
            {
                Id = 1,
                Username = "",
                Password = "test",
                ApiToken = "success",
            }, null, null, null, null);

            // Act
            var apiToken = user.VerifyPassword(new string('a', 81));

            // Assert
            Assert.AreEqual(null, apiToken);
        }

        [TestMethod()]
        public async Task SaveAsyncTest()
        {
            // Arrange
            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock
                .Setup(mock => mock.UpdateUserByIdAsync(1, It.Is((UpdateUserDataDto data) => (
                    data.Username == "updated"
                ))))
                .ReturnsAsync(true)
                .Verifiable();

            var user = new User(new UserDataDto
            {
                Id = 1,
                Username = "test",
                Password = "",
                ApiToken = "",
            }, userRepoMock.Object, null, null, null);

            // Act
            user.Username = "updated";
            var success = await user.SaveAsync();

            // Assert
            userRepoMock.Verify();
            Assert.AreEqual(true, success);
        }

        [TestMethod()]
        public async Task GetLikedSongIdsAsyncTest()
        {
            // Arrange
            var songCollectionMock = new Mock<ISongCollection>();
            songCollectionMock
                .Setup(mock => mock.GetLikedSongIdsByUserIdAsync(1))
                .ReturnsAsync(new[] { 1 })
                .Verifiable();

            var user = new User(new UserDataDto
            {
                Id = 1,
                Username = "",
                Password = "",
                ApiToken = "",
            }, null, songCollectionMock.Object, null, null);

            // Act
            var likedSongs = (await user.GetLikedSongIdsAsync()).ToArray();

            // Assert
            songCollectionMock.Verify();
            Assert.AreEqual(1, likedSongs.Length);
            Assert.AreEqual(1, likedSongs[0]);
        }

        [TestMethod()]
        public async Task GetLikedAlbumIdsAsyncTest()
        {
            // Arrange
            var albumCollectionMock = new Mock<IAlbumCollection>();
            albumCollectionMock
                .Setup(mock => mock.GetLikedAlbumIdsByUserIdAsync(1))
                .ReturnsAsync(new[] { 1 })
                .Verifiable();

            var user = new User(new UserDataDto
            {
                Id = 1,
                Username = "",
                Password = "",
                ApiToken = "",
            }, null, null, albumCollectionMock.Object, null);

            // Act
            var likedAlbums = (await user.GetLikedAlbumIdsAsync()).ToArray();

            // Assert
            albumCollectionMock.Verify();
            Assert.AreEqual(1, likedAlbums.Length);
            Assert.AreEqual(1, likedAlbums[0]);
        }

        [TestMethod()]
        public async Task GetLikedArtistIdsAsyncTest()
        {
            // Arrange
            var artistCollectionMock = new Mock<IArtistCollection>();
            artistCollectionMock
                .Setup(mock => mock.GetLikedArtistIdsByUserIdAsync(1))
                .ReturnsAsync(new[] { 1 })
                .Verifiable();

            var user = new User(new UserDataDto
            {
                Id = 1,
                Username = "",
                Password = "",
                ApiToken = "",
            }, null, null, null, artistCollectionMock.Object);

            // Act
            var likedArtists = (await user.GetLikedArtistIdsAsync()).ToArray();

            // Assert
            artistCollectionMock.Verify();
            Assert.AreEqual(1, likedArtists.Length);
            Assert.AreEqual(1, likedArtists[0]);
        }
    }
}
