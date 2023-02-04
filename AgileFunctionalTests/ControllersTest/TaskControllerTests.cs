using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgileApp.Controllers;
using AgileApp.Models.Tasks;
using AgileApp.Services.Tasks;
using AgileApp.Utils.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace AgileFunctionalTests.ControllersTest
{
    public class TaskControllerTests
    {
        private readonly Mock<ITaskService> _taskServiceMock;
        private readonly Mock<ICookieHelper> _cookieHelperMock;
        private readonly TaskController _taskController;

        public TaskControllerTests()
        {
            _taskServiceMock = new Mock<ITaskService>();
            _cookieHelperMock = new Mock<ICookieHelper>();
            _taskController = new TaskController(_taskServiceMock.Object, _cookieHelperMock.Object);
        }
    }
}
