using Microsoft.AspNetCore.Mvc;

namespace AgileApp.Controllers
{
    public class FileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
