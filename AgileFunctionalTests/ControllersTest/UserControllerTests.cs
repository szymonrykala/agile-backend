using AgileApp.Controllers;
using AgileApp.Services.Users;
using AgileApp.Utils.Cookies;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace AgileFunctionalTests.ControllersTest
{
    public class UserControllerTests
    {
        private readonly UserController _controller;
        private readonly Mock<IUserService> _userServiceMock;
        private readonly Mock<ICookieHelper> _cookieHelperMock;

        public UserControllerTests()
        {
            _userServiceMock = new Mock<IUserService>();
            _cookieHelperMock = new Mock<ICookieHelper>();
            _controller = new UserController(_userServiceMock.Object, _cookieHelperMock.Object);
        }

        [Fact]
        public async Task Login_ShouldReturnBadRequest_WhenCalledWithNullRequest()
        {
            // Act
            var result = await _controller.Login(null);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
