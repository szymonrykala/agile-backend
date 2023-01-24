using AgileApp.Models.Tasks;
using AgileApp.Services.Tasks;
using AgileApp.Utils.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace AgileApp.Controllers
{
    [Route("tasks/[action]")]
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

        //TODO: DELETE METHODS SHOULD PROVIDE SOME LOGIC!!!

        [HttpPost]
        public IActionResult AddTask([FromBody] AddTaskRequest request)
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

            var creationResult = _taskService.AddNewTask(request);

            if (creationResult == null)
            {
                return new OkObjectResult(Models.Common.Response.Failed());
            }

            return new OkObjectResult(true);
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var reverseTokenResult = _cookieHelper.ReverseJwtFromRequest(HttpContext);

            if (!reverseTokenResult.IsValid)
            {
                return new BadRequestResult();
            }

            return new OkObjectResult(_taskService.GetAllTasks());
        }

        [HttpGet]
        public IActionResult GetTaskById(int id)
        {
            var reverseTokenResult = _cookieHelper.ReverseJwtFromRequest(HttpContext);

            if (id < 1 || !reverseTokenResult.IsValid)
            {
                return BadRequest();
            }

            return new OkObjectResult(_taskService.GetTaskById(id));
        }

        [HttpPatch]
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
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return new OkObjectResult(_taskService.UpdateTask(taskUpdate));
        }

        [HttpDelete]
        public IActionResult DeleteTask(int id)
        {
            var reverseTokenResult = _cookieHelper.ReverseJwtFromRequest(HttpContext);

            if (id < 1 || !reverseTokenResult.IsValid)
            {
                return BadRequest();
            }

            return new OkObjectResult(_taskService.DeleteTask(id));
        }
    }
}
