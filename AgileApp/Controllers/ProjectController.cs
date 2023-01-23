using Microsoft.AspNetCore.Mvc;

namespace AgileApp.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
