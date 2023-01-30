using AgileApp.Enums;
using AgileApp.Models;
using AgileApp.Models.Requests;
using AgileApp.Services.Users;
using AgileApp.Utils.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace AgileApp.Controllers
{
    [Route("users/")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICookieHelper _cookieHelper;

        public UserController(
            IUserService userService,
            ICookieHelper cookieHelper)
        {
            _userService = userService;
            _cookieHelper = cookieHelper;
        }

        [HttpDelete("logout/")]
        public IActionResult Logout() => new OkObjectResult(_cookieHelper.InvalidateJwtCookie(HttpContext));

        [HttpPost("login/")]
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
                _cookieHelper.AddJwtToHttpOnlyResponseCookie(HttpContext, request.Email, authorizationResult.Id, authorizationResult.Role);
            }

            return new OkObjectResult(true);
        }

        [HttpPost("")]
        public IActionResult AddUser([FromBody] AuthorizationDataRequest request)
        {
            var reverseTokenResult = _cookieHelper.ReverseJwtFromRequest(HttpContext);

            if (request == null || !request.IsValid || !reverseTokenResult.IsValid || !RoleCheckUtils.IsAdmin(reverseTokenResult))
            {
                return BadRequest();
            }

            var isEmailTaken = _userService.IsEmailTaken(request.Email);

            if (request.Email == null || request.FirstName == null || request.LastName == null)
            {
                return new OkObjectResult(Models.Common.Response.Failed());
            }

            if (isEmailTaken)
            {
                return new OkObjectResult(Models.Common.Response.Failed());
            }

            var registerResult = _userService.AddUser(request);

            if (registerResult == null)
            {
                return new OkObjectResult(Models.Common.Response.Failed());
            }

            return new OkObjectResult(true);
        }

        [HttpGet("")]
        public IActionResult GetAllUsers()
        {
            var reverseTokenResult = _cookieHelper.ReverseJwtFromRequest(HttpContext);

            if (!reverseTokenResult.IsValid || !RoleCheckUtils.IsAdmin(reverseTokenResult))
            {
                return new BadRequestResult();
            }

            string hash = reverseTokenResult.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.Hash)?.Value;

            return string.IsNullOrWhiteSpace(hash)
                ? (IActionResult)new BadRequestResult()
                : new OkObjectResult(_userService.GetAllUsers());
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserById(int userId)
        {
            var reverseTokenResult = _cookieHelper.ReverseJwtFromRequest(HttpContext);

            if (userId < 1 || !reverseTokenResult.IsValid)
            {
                return BadRequest();
            }

            return new OkObjectResult(_userService.GetUserById(userId));
        }

        [HttpPatch("{userId}")]
        public IActionResult UpdateUser([FromBody] UpdateUserRequest request)
        {
            var reverseTokenResult = _cookieHelper.ReverseJwtFromRequest(HttpContext);

            if (request == null || !reverseTokenResult.IsValid || !RoleCheckUtils.IsAdmin(reverseTokenResult))
            {
                return BadRequest();
            }


            var userUpdate = new UpdateUserRequest();
            try
            {
                userUpdate.Id = request.Id;
                userUpdate.FirstName = request.FirstName ?? string.Empty;
                userUpdate.LastName = request.LastName ?? string.Empty;
                userUpdate.Email = request.Email ?? string.Empty;
                userUpdate.Password = request.Password ?? string.Empty;
                userUpdate.Role = request.Role ?? _userService.GetUserById(request.Id).Role;
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return new OkObjectResult(_userService.UpdateUser(userUpdate));
        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            var reverseTokenResult = _cookieHelper.ReverseJwtFromRequest(HttpContext);

            if (userId < 1 || !reverseTokenResult.IsValid || !RoleCheckUtils.IsAdmin(reverseTokenResult))
            {
                return BadRequest();
            }

            return new OkObjectResult(_userService.DeleteUser(userId));
        }
    }
}
