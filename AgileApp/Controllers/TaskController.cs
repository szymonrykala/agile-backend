using AgileApp.Models.Tasks;
using AgileApp.Services.Tasks;
using AgileApp.Utils.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace AgileApp.Controllers
{
    [Route("tasks/")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly ICookieHelper _cookieHelper;

        public TaskController(
            ITaskService taskService,
            ICookieHelper cookieHelper)
        {
            _taskService = taskService;
            _cookieHelper = cookieHelper;
        }

        [HttpGet("")]
        public IActionResult GetAllTasks()
        {
            var reverseTokenResult = _cookieHelper.ReverseJwtFromRequest(HttpContext);

            if (!reverseTokenResult.IsValid)
            {
                return new BadRequestResult();
            }

            return new OkObjectResult(_taskService.GetAllTasks());
        }

        [HttpGet("{taskId}")]
        public IActionResult GetTaskById(int taskId)
        {
            var reverseTokenResult = _cookieHelper.ReverseJwtFromRequest(HttpContext);

            if (taskId < 1 || !reverseTokenResult.IsValid)
            {
                return BadRequest();
            }

            return new OkObjectResult(_taskService.GetTaskById(taskId));
        }

        [HttpPatch("{taskId}")]
        public IActionResult UpdateTask([FromBody] UpdateTaskRequest request)
        {
            var reverseTokenResult = _cookieHelper.ReverseJwtFromRequest(HttpContext);

            if (request == null || !reverseTokenResult.IsValid)
            {
                return BadRequest();
            }

            var taskUpdate = new UpdateTaskRequest();
            try
            {
                taskUpdate.Id = request.Id;
                taskUpdate.Name = request.Name ?? string.Empty;
                taskUpdate.Description = request.Description ?? string.Empty;
                taskUpdate.Status = request.Status;
                taskUpdate.UserId = request.UserId;
                taskUpdate.ProjectId = request.ProjectId;

                return new OkObjectResult(_taskService.UpdateTask(taskUpdate));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{taskId}")]
        public IActionResult DeleteTask(int taskId)
        {
            var reverseTokenResult = _cookieHelper.ReverseJwtFromRequest(HttpContext);

            if (taskId < 1 || !reverseTokenResult.IsValid)
            {
                return BadRequest();
            }

            return new OkObjectResult(_taskService.DeleteTask(taskId));
        }
    }
}
