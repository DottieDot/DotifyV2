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
            var album = await song.GetAlbumAsync();

            albumCollectionMock.Verify();
            Assert.AreEqual(1, song.Id);
        }

        [TestMethod()]
        public async Task LikeAsyncTest()
        {
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
            var success = await song.LikeAsync(1);

            songRepoMock.Verify();
            Assert.AreEqual(true, success);
        }

        [TestMethod()]
        public async Task RemoveLikeAsyncTest()
        {
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
            var success = await song.RemoveLikeAsync(1);

            songRepoMock.Verify();
            Assert.AreEqual(true, success);
        }
    }
}
