using AgileApp.Controllers;
using AgileApp.Services.Projects;
using AgileApp.Services.Tasks;
using AgileApp.Utils.Cookies;
using Moq;

namespace AgileFunctionalTests.ControllersTest
{
    public class ProjectControllerTests
    {
        private readonly Mock<IProjectService> _projectServiceMock;
        private readonly Mock<ICookieHelper> _cookieHelperMock;
        private readonly Mock<ITaskService> _taskServiceMock;
        private readonly ProjectController _controller;

        public ProjectControllerTests()
        {
            _projectServiceMock = new Mock<IProjectService>();
            _cookieHelperMock = new Mock<ICookieHelper>();
            _taskServiceMock = new Mock<ITaskService>();
            _controller = new ProjectController(
                _projectServiceMock.Object,
                _cookieHelperMock.Object,
                _taskServiceMock.Object);
        }
    }
}
