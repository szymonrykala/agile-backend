using AgileApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AgileUnitTests.ControllersTest
{
    public class FileControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult()
        {
            // Arrange
            var fileController = new FileController();

            // Act
            var result = fileController.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }
    }

}
