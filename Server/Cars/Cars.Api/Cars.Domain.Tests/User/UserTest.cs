using System;
using Cars.Common.Enums;
using Cars.Domain.DomainExceptions;
using Xunit;

namespace Cars.Domain.Tests.User
{
    public class UserTest
    {
        public UserTest()
        {
            //Arrange
            //Act
            //Assert
        }

        [Fact]
        public void CreateUser_Returns_Correct_Response()
        {
            var user = new Domain.User.User("Name", "Email", "login2", "password");
            
            Assert.Equal("Email", user.Email);
            Assert.Equal("Name", user.UserName);
        }

    }
}