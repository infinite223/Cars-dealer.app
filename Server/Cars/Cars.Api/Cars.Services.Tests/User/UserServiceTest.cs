using System;
using System.Threading.Tasks;
using Cars.Common.Enums;
using Cars.Domain.DomainExceptions;
using Cars.IData.User;
using Cars.IServices.Requests;
using Cars.IServices.User;
using Cars.Services.User;
using Moq;
using Xunit;

namespace Cars.Services.Tests.User
{
    public class UserServiceTest
    {
        private readonly IUserService _userService;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        
        public UserServiceTest()
        {
            //Arrange
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object);
        }
        
        [Fact]
        public void CreateUser_Returns_throws_InvalidBirthDateException()
        {
            var user = new CreateUser
            {
                Email = "Email",
                UserName = "Name",
                Login = "login2",
                Password = "password",
            };

            Assert.ThrowsAsync<InvalidBirthDateException>(() => _userService.CreateUser(user));
        }
        
        [Fact]
        public async Task CreateUser_Returns_Correct_Response()
        {
            var user = new CreateUser
            {
                Email = "Email",
                UserName = "Name",
                Login = "login2",
                Password = "password",
            };
            
            int expectedResult = 0;
            _userRepositoryMock.Setup(x => x.AddUser
                (new Domain.User.User
                (user.UserName, 
                    user.Email,
                    user.Login,
                    user.Password
                   )))
                .Returns(Task.FromResult(expectedResult));
            
            //Act
            var result = await _userService.CreateUser(user);

            //Assert
            Assert.IsType<Domain.User.User>(result);
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.Id);
        }

    }
}