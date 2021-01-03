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
            var user = new User(new UserDataDto
            {
                Id = 1,
                Username = "",
                Password = "",
                ApiToken = "",
            }, null, null, null);

            var result = user.SetPassword("test");

            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void SetPasswordTest_TooLongPassword_False()
        {
            var user = new User(new UserDataDto
            {
                Id = 1,
                Username = "",
                Password = "",
                ApiToken = "",
            }, null, null, null);

            var result = user.SetPassword(new string('a', 81));

            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public void VerifyPasswordTest_CorrectPassword_ApiToken()
        {
            var user = new User(new UserDataDto
            {
                Id = 1,
                Username = "",
                Password = "test",
                ApiToken = "success",
            }, null, null, null);

            var apiToken = user.VerifyPassword("test");

            Assert.AreEqual("success", apiToken);
        }

        [TestMethod()]
        public void VerifyPasswordTest_IncorrectPassword_Null()
        {
            var user = new User(new UserDataDto
            {
                Id = 1,
                Username = "",
                Password = "test",
                ApiToken = "success",
            }, null, null, null);

            var apiToken = user.VerifyPassword("hey");

            Assert.AreEqual(null, apiToken);
        }

        [TestMethod()]
        public void VerifyPasswordTest_InvalidPassword_Null()
        {
            var user = new User(new UserDataDto
            {
                Id = 1,
                Username = "",
                Password = "test",
                ApiToken = "success",
            }, null, null, null);

            var apiToken = user.VerifyPassword(new string('a', 81));

            Assert.AreEqual(null, apiToken);
        }

        [TestMethod()]
        public async Task TaskAsyncTest()
        {
            // TODO: Test
        }

        [TestMethod()]
        public async Task GetLikedSongIdsAsyncTest()
        {
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
            }, songCollectionMock.Object, null, null);

            var likedSongs = (await user.GetLikedSongIdsAsync()).ToArray();

            songCollectionMock.Verify();
            Assert.AreEqual(1, likedSongs.Length);
            Assert.AreEqual(1, likedSongs[0]);
        }

        [TestMethod()]
        public async Task GetLikedAlbumIdsAsyncTest()
        {
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
            }, null, albumCollectionMock.Object, null);

            var likedAlbums = (await user.GetLikedAlbumIdsAsync()).ToArray();

            albumCollectionMock.Verify();
            Assert.AreEqual(1, likedAlbums.Length);
            Assert.AreEqual(1, likedAlbums[0]);
        }

        [TestMethod()]
        public async Task GetLikedArtistIdsAsyncTest()
        {
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
            }, null, null, artistCollectionMock.Object);

            var likedArtists = (await user.GetLikedArtistIdsAsync()).ToArray();

            artistCollectionMock.Verify();
            Assert.AreEqual(1, likedArtists.Length);
            Assert.AreEqual(1, likedArtists[0]);
        }
    }
}
