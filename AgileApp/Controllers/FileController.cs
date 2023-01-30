using AgileApp.Models.Files;
using Microsoft.AspNetCore.Mvc;

namespace AgileApp.Controllers
{
    [Route("files/")]
    public class FileController : Controller
    {
        [HttpGet("")]
        public IActionResult GetFiles([FromBody] GetFilesRequest request)
        {
            return View();
        }

        [HttpPost("")]
        public IActionResult UploadFile([FromBody] UploadFileRequest request)
        {
            return View();
        }

        [HttpGet("{fileId}")]
        public IActionResult GetFileById(int fileId)
        {
            return View();
        }

        [HttpDelete("{fileId}")]
        public IActionResult DeleteFile(int fileId)
        {
            return View();
        }
    }
}
