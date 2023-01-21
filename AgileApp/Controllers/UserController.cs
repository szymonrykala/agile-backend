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

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            _cookieHelper.AddJwtToHttpOnlyResponseCookie(HttpContext, "panrysio@gmail.com", "fhdaskjfhaskjf4T#tfggiudfngjkdfngk");

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
