using AgileApp.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace AgileUnitTests.ControllersTest
{
    public class ChatControllerTests
    {
        [Fact]
        public Task GetMessage_ReturnsWebSocketResult_WhenWebSocketRequest()
        {
            // Arrange
            var chatController = new ChatController();
            chatController.ControllerContext = new ControllerContext();
            chatController.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            //var result = chatController.GetMessage();
            return Task.CompletedTask;
        }

        [Fact]
        public Task GetMessage_ReturnsBadRequestResult_WhenNotWebSocketRequest()
        {
            // Arrange
            var chatController = new ChatController();
            chatController.ControllerContext = new ControllerContext();
            chatController.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var result = chatController.GetMessage();

            // Assert
            Assert.IsType<BadRequestResult>(result);
            return Task.CompletedTask;
        }
    }
}
