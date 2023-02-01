using AgileApp.Models.Common;

namespace AgileApp.Services.Files
{
    public interface IFileService
    {
        public Response<bool> UploadFile(Models.Files.UploadFileRequest file);
    }
}
