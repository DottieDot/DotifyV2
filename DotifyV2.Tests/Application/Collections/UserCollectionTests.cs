using System;
using System.Threading.Tasks;
using DotifyV2.Application.DTOs;
using DotifyV2.Application.Repositories;
using DotifyV2.Application.Collections;
using DotifyV2.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DotifyV2.Tests.Application.Collections
{
    [TestClass()]
	public class UserCollectionTests
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
		public async Task GetUserByIdAsync_ValidId_CorrectData()
		{
			var userRepoMock = new Mock<IUserRepository>();
			userRepoMock.Setup(userRepo => userRepo.GetUserByIdAsync(0))
				.ReturnsAsync(new UserDataDto
						{
							Id = 0,
							Username = "JohnDoe",
							Password = "Password",
							ApiToken = "1337"
						});

			var userCollection = new UserCollection(userRepoMock.Object, _dependencyMapper);

			var user = await userCollection.GetUserByIdAsync(0);

			Assert.AreEqual(0, user.Id);
			Assert.AreEqual("JohnDoe", user.Username);
		}

		[TestMethod()]
		public async Task GetUserByIdAsync_InvalidId_Null()
		{
			var userRepoMock = new Mock<IUserRepository>();

			var userCollection = new UserCollection(userRepoMock.Object, _dependencyMapper);
			var user = await userCollection.GetUserByIdAsync(0);

			Assert.AreEqual(null, user);
		}

		[TestMethod()]
		public async Task GetUserByUsernameAsync_ValidUsername_CorrectData()
		{
			var userRepoMock = new Mock<IUserRepository>();
			userRepoMock.Setup(userRepo => userRepo.GetUserByUsernameAsync("JohnDoe"))
				.ReturnsAsync(new UserDataDto
				{
					Id = 0,
					Username = "JohnDoe",
					Password = "Password",
					ApiToken = "1337"
				});

			var userCollection = new UserCollection(userRepoMock.Object, _dependencyMapper);

			var user = await userCollection.GetUserByUsernameAsync("JohnDoe");

			Assert.AreEqual(0, user.Id);
			Assert.AreEqual("JohnDoe", user.Username);
		}

		[TestMethod()]
		public async Task GetUserByUsernameAsync_InvalidUsername_Null()
		{
			var userRepoMock = new Mock<IUserRepository>();

			var userCollection = new UserCollection(userRepoMock.Object, _dependencyMapper);
			var user = await userCollection.GetUserByUsernameAsync("JohnDoe");

			Assert.AreEqual(null, user);
		}

		[TestMethod()]
		public async Task GetUserByApiTokenAsync_ValidApiToken_CorrectData()
		{
			var userRepoMock = new Mock<IUserRepository>();
			userRepoMock.Setup(userRepo => userRepo.GetUserByApiTokenAsync("1337"))
				.ReturnsAsync(new UserDataDto
				{
					Id = 0,
					Username = "JohnDoe",
					Password = "Password",
					ApiToken = "1337"
				});

			var userCollection = new UserCollection(userRepoMock.Object, _dependencyMapper);

			var user = await userCollection.GetUserByApiTokenAsync("1337");

			Assert.AreEqual(0, user.Id);
			Assert.AreEqual("JohnDoe", user.Username);
		}

		[TestMethod()]
		public async Task GetUserByApiTokenAsync_InvalidApiToken_Null()
		{
			var userRepoMock = new Mock<IUserRepository>();

			var userCollection = new UserCollection(userRepoMock.Object, _dependencyMapper);
			var user = await userCollection.GetUserByApiTokenAsync("1337");

			Assert.AreEqual(null, user);
		}

		[TestMethod()]
		public async Task CreateUserAsyncTest()
		{	
			var userRepoMock = new Mock<IUserRepository>();
			userRepoMock.Setup(v =>
				v.CreateUserAsync(It.Is((NewUserDataDto data) =>
					(data.Username == "JohnDoe") &&
					(data.Password == "Password") &&
					(data.ApiToken.Length == 255))))
				.ReturnsAsync(new UserDataDto
				{
					Id = 0,
					Username = "JohnDoe",
					Password= "Password",
					ApiToken = "1337",
				}).Verifiable();

			var userCollection = new UserCollection(userRepoMock.Object, _dependencyMapper);
			var user = await userCollection.CreateUserAsync("JohnDoe", "Password");

			Assert.AreEqual(0, user.Id);
			Assert.AreEqual("JohnDoe", user.Username);
			userRepoMock.Verify();
		}
	}
}