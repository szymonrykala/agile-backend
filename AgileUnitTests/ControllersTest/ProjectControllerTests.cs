using AgileApp.Controllers;
using AgileApp.Models.Projects;
using AgileApp.Models.Tasks;
using AgileApp.Services.Projects;
using AgileApp.Services.Tasks;
using AgileApp.Utils.Cookies;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AgileUnitTests.ControllersTest
{
    public class ProjectControllerTests
    {
        private readonly IProjectService _projectService;
        private readonly ICookieHelper _cookieHelper;
        private readonly ITaskService _taskService;
        private readonly ProjectController _controller;

        public ProjectControllerTests()
        {

        }

        [Fact]
        public void AddProject_InvalidRequest_ReturnsBadRequest()
        {
            var result = _controller.AddProject(null);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void AddProject_NoNameProvided_ReturnsFailedResponse()
        {
            var result = _controller.AddProject(new AddProjectRequest());

            var objectResult = result as OkObjectResult;
            var response = objectResult?.Value as AgileApp.Models.Common.Response;

            Assert.False(response.IsSuccess);
        }

        [Fact]
        public void AddProject_ValidRequest_ReturnsOkResult()
        {
            var result = _controller.AddProject(new AddProjectRequest { Name = "Test project" });

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void AddTask_InvalidRequest_ReturnsBadRequest()
        {
            var result = _controller.AddTask(null);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void AddTask_NoNameProvided_ReturnsFailedResponse()
        {
            var result = _controller.AddTask(new AddTaskRequest());

            var objectResult = result as OkObjectResult;
            var response = objectResult?.Value as AgileApp.Models.Common.Response;

            Assert.False(response.IsSuccess);
        }

        [Fact]
        public void AddTask_ValidRequest_ReturnsOkResult()
        {
            var result = _controller.AddTask(new AddTaskRequest { Name = "Test task" });

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetAllProjects_InvalidToken_ReturnsBadRequest()
        {
            var result = _controller.GetAllProjects();

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void GetProjectById_InvalidId_ReturnsBadRequest()
        {
            var result = _controller.GetProjectById(0);

            Assert.IsType<BadRequestResult>(result);
        }
    }
}
