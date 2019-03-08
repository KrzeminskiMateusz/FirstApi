using AutoMapper;
using FirstApi.Core.Domain;
using FirstApi.Core.Repositories;
using FirstApi.Infrastructure.Services;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Register()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            await userService.RegisterAsync("email@email.pl", "user", "password");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);


        }
    }
}