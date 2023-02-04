using AgileApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace AgileFunctionalTests.ControllersTest
{
    public class HomeControllerTests
    {
        private readonly Mock<ILogger<HomeController>> _mockLogger;

        public HomeControllerTests()
        {
            _mockLogger = new Mock<ILogger<HomeController>>();
        }

        [Fact]
        public void Index_ShouldReturnViewResult()
        {
            var controller = new HomeController(_mockLogger.Object);

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Privacy_ShouldReturnViewResult()
        {
            var controller = new HomeController(_mockLogger.Object);

            var result = controller.Privacy();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Error_ShouldReturnViewResult()
        {
            var controller = new HomeController(_mockLogger.Object);

            var result = controller.Error();

            Assert.IsType<ViewResult>(result);
        }
    }
}
