using Microsoft.AspNetCore.Mvc;

namespace AgileApp.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
