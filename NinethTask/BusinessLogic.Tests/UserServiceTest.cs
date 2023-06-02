using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests
{
    public class UserServiceTest
    {
        private readonly UserService service;
        private readonly Mock<IUserRepository> userRepositoryMoq;
        public UserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMoq = new Mock<IUserRepository>();

            repositoryWrapperMoq.Setup(x => x.User)
                .Returns(userRepositoryMoq.Object);

            service = new UserService(repositoryWrapperMoq.Object);
        }

        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[] {new User() { id_user = 1, Login = "", Password = "", RoleId = 0, Address = "", IsDeleted = false} },
                new object[] {new User() { id_user = 2, Login = "Test", Password = "", RoleId = 0, Address = "", IsDeleted = false} },
                new object[] {new User() { id_user = 3, Login = "Test", Password = "Test", RoleId = 1, Address = "Address", IsDeleted = false } },
            };
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsyncNewUserShouldNotCreateNewUser(User user)
        {
            var newUser = user;
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewUser()
        {
            var newUser = new User()
            {
                id_user = 55,
                Login = "Testlogin",
                Password = "Testpassword",
                RoleId = 34,
                Address = "TestAddress",
                IsDeleted = false
            };

            await service.Create(newUser);

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Once);

        }
    }
}
