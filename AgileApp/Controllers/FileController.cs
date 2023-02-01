using AgileApp.Models.Files;
using AgileApp.Services.Files;
using Microsoft.AspNetCore.Mvc;

namespace AgileApp.Controllers
{
    [Route("files/")]
    public class FileController : Controller
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("")]
        public IActionResult GetFiles([FromBody] GetFilesRequest request)
        {
            return View();
        }

        [HttpPost("")]
        public IActionResult UploadFile([FromForm] UploadFileRequest request)
        {
            return new OkObjectResult(_fileService.UploadFile(request));
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
