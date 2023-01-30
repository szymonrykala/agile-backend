using AgileApp.Controllers;
using AgileApp.Models.Requests;
using AgileApp.Services.Users;
using AgileApp.Utils.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AgileUnitTests.ControllersTest
{
    public class UserControllerTests
    {
        private readonly UserController _controller;
        private readonly IUserService _userService;
        private readonly ICookieHelper _cookieHelper;

        public UserControllerTests()
        {

        }

        [Fact]
        public void Logout_ReturnsOkObjectResult()
        {
            var result = _controller.Logout();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Login_WithValidRequest_ReturnsOkObjectResult()
        {
            var request = new AuthorizationDataRequest { Email = "test@email.com", Password = "password" };
            var result = await _controller.Login(request);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Login_WithNullRequest_ReturnsBadRequestResult()
        {
            var result = _controller.Login(null);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void AddUser_WithValidRequest_ReturnsOkObjectResult()
        {
            var request = new AuthorizationDataRequest { Email = "test@email.com", FirstName = "Test", LastName = "User", Password = "password" };
            var context = new DefaultHttpContext();
            context.Request.Headers["Authorization"] = "Bearer testToken";
            _controller.ControllerContext = new ControllerContext { HttpContext = context };

            var result = _controller.AddUser(request);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void AddUser_WithNullRequest_ReturnsBadRequestResult()
        {
            var result = _controller.AddUser(null);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void GetAllUsers_WithValidToken_ReturnsOkObjectResult()
        {
            var context = new DefaultHttpContext();
            context.Request.Headers["Authorization"] = "Bearer testToken";
            _controller.ControllerContext = new ControllerContext { HttpContext = context };

            var result = _controller.GetAllUsers();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetAllUsers_WithInvalidToken_ReturnsBadRequestResult()
        {
            var result = _controller.GetAllUsers();

            Assert.IsType<BadRequestResult>(result);
        }
    }
}
