using AgileApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AgileFunctionalTests.ControllersTest
{
    public class FileControllerTests
    {
        [Fact]
        public void Index_ShouldReturnViewResult()
        {
            var controller = new FileController();

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }
    }
}
