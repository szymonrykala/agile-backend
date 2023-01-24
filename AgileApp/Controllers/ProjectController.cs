using AgileApp.Models.Projects;
using AgileApp.Services.Projects;
using AgileApp.Utils.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace AgileApp.Controllers
{
    [Route("projects/[action]")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly ICookieHelper _cookieHelper;

        public ProjectController(
            IProjectService projectService,
            ICookieHelper cookieHelper)
        {
            _projectService = projectService;
            _cookieHelper = cookieHelper;
        }

        [HttpPost]
        public IActionResult AddProject([FromBody] AddProjectRequest request)
        {
            var reverseTokenResult = _cookieHelper.ReverseJwtFromRequest(HttpContext);

            if (request == null || !reverseTokenResult.IsValid)
            {
                return BadRequest();
            }

            if (request.Name == null)
            {
                return new OkObjectResult(Models.Common.Response.Failed());
            }

            var creationResult = _projectService.AddNewProject(request);

            if (creationResult == null)
            {
                return new OkObjectResult(Models.Common.Response.Failed());
            }

            return new OkObjectResult(true);
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var reverseTokenResult = _cookieHelper.ReverseJwtFromRequest(HttpContext);

            if (!reverseTokenResult.IsValid)
            {
                return new BadRequestResult();
            }

            return new OkObjectResult(_projectService.GetAllProjects());
        }

        [HttpGet]
        public IActionResult GetProjectById(int id)
        {
            var reverseTokenResult = _cookieHelper.ReverseJwtFromRequest(HttpContext);

            if (id < 1 || !reverseTokenResult.IsValid)
            {
                return BadRequest();
            }

            return new OkObjectResult(_projectService.GetProjectById(id));
        }

        [HttpPatch]
        public IActionResult UpdateProject([FromBody] UpdateProjectRequest request)
        {
            var reverseTokenResult = _cookieHelper.ReverseJwtFromRequest(HttpContext);

            if (request == null || !reverseTokenResult.IsValid)
            {
                return BadRequest();
            }

            var projectUpdate = new UpdateProjectRequest();
            try
            {
                projectUpdate.Id = request.Id;
                projectUpdate.Name = request.Name ?? string.Empty;
                projectUpdate.Description = request.Description ?? string.Empty;
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return new OkObjectResult(_projectService.UpdateProject(projectUpdate));
        }

        [HttpDelete]
        public IActionResult DeleteProject(int id)
        {
            var reverseTokenResult = _cookieHelper.ReverseJwtFromRequest(HttpContext);

            if (id < 1 || !reverseTokenResult.IsValid)
            {
                return BadRequest();
            }

            return new OkObjectResult(_projectService.DeleteProject(id));
        }
    }
}
