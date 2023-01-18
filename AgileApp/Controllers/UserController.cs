using AgileApp.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace AgileApp.Controllers
{
    [Route("users/[action]")]
    public class UserController : Controller
    {
        //private readonly ILogger _logger;
        private readonly IUserService _userService;

        public UserController(
            //ILogger logger,
            IUserService userService)
        {
            //_logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return new OkObjectResult(_userService.GetAllUsers());
        }
    }
}
