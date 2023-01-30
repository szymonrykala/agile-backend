using AgileApp.Controllers;
using AgileApp.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AgileUnitTests.ControllersTest
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Privacy_ReturnsViewResult()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.Privacy();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Error_ReturnsViewResult()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.Error();

            // Assert
            Assert.IsType<ViewResult>(result);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<ErrorViewModel>(viewResult.Model);
        }
    }
}
