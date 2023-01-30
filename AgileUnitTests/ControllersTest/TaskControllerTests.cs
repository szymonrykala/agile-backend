using AgileApp.Controllers;
using AgileApp.Services.Tasks;
using AgileApp.Utils.Cookies;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace AgileUnitTests.ControllersTest
{
    public class TaskControllerTests
    {
        private readonly TaskController _taskController;
        private readonly ITaskService _taskServiceMock;
        private readonly ICookieHelper _cookieHelperMock;

        public TaskControllerTests()
        {
            _taskServiceMock = Substitute.For<ITaskService>();
            _cookieHelperMock = Substitute.For<ICookieHelper>();

            _taskController = new TaskController(
                _taskServiceMock,
                _cookieHelperMock);
        }

        [Fact]
        public void GetAllTasks_ShouldReturnBadRequestResult_WhenReverseTokenResultIsNotValid()
        {
            // Arrange

            // Act
            var result = _taskController.GetAllTasks();

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void GetAllTasks_ShouldReturnOkObjectResult_WhenReverseTokenResultIsValid()
        {
            // Arrange

            // Act
            var result = _taskController.GetAllTasks();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetTaskById_ShouldReturnBadRequest_WhenTaskIdIsLessThan1OrReverseTokenResultIsNotValid()
        {
            // Arrange

            // Act
            var result = _taskController.GetTaskById(0);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void GetTaskById_ShouldReturnOkObjectResult_WhenTaskIdIsGreaterThan0AndReverseTokenResultIsValid()
        {
            // Arrange

            // Act
            var result = _taskController.GetTaskById(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
