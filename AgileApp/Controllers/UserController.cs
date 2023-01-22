using AgileApp.Models.Requests;
using AgileApp.Services.Users;
using AgileApp.Utils.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace AgileApp.Controllers
{
    [Route("users/[action]")]
    public class UserController : Controller
    {
        //private readonly ILogger _logger;
        private readonly IUserService _userService;
        private readonly ICookieHelper _cookieHelper;

        public UserController(
            //ILogger logger,
            IUserService userService,
            ICookieHelper cookieHelper)
        {
            //_logger = logger;
            _userService = userService;
            _cookieHelper = cookieHelper;
        }

        [HttpDelete]
        public IActionResult Logout() => new OkObjectResult(_cookieHelper.InvalidateJwtCookie(HttpContext));

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AuthorizationDataRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var authorizationResult = await _userService.AuthorizeUser(request);

            if (authorizationResult == null)
            {
                return new OkObjectResult(false);
            }

            if (authorizationResult.Exists)
            {
                _cookieHelper.AddJwtToHttpOnlyResponseCookie(HttpContext, request.Email, authorizationResult.Hash);
            }

            return new OkObjectResult(true);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] AuthorizationDataRequest request)
        {
            if (request == null || !request.IsValid)
            {
                return BadRequest();
            }

            var isEmailTaken = _userService.IsEmailTaken(request.Email);

            if (!isEmailTaken)
            {
                return new OkObjectResult(Models.Common.Response.Failed());
            }

            var registerResult = _userService.AddUser(request);

            if (registerResult != null)
            {
                return new OkObjectResult(Models.Common.Response.Failed());
            }

            _cookieHelper.AddJwtToHttpOnlyResponseCookie(HttpContext, request.Email, registerResult);
            return new OkObjectResult(true);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var reverseTokenResult = _cookieHelper.ReverseJwtFromRequest(HttpContext);

            if (!reverseTokenResult.IsValid)
            {
                return new BadRequestResult();
            }

            string hash = reverseTokenResult.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.Hash)?.Value;

            return string.IsNullOrWhiteSpace(hash)
                ? (IActionResult)new BadRequestResult()
                : new OkObjectResult(_userService.GetAllUsers());
        }
    }
}
