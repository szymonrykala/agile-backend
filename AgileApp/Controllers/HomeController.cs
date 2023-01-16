using AgileApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgileApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            using var ctx = new AgileContext();
            _ = ctx.Database.EnsureCreated();

            // Insert a Blog
            ctx?.Users?.Add(new() { Id=2, Name = "FooUser2" });
            ctx?.SaveChanges();

            // Query all blogs who's name starts with F
            var fBlogs = ctx?.Users?.Where(b => b.Name.StartsWith("F")).ToList();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}