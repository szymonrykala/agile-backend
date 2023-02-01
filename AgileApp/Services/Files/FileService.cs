using AgileApp.Models.Common;

namespace AgileApp.Services.Files
{
    public class FileService : IFileService
    {
        public Response<bool> UploadFile(Models.Files.UploadFileRequest file)
        {
            if (file == null)
                return Response<bool>.Failed("The file is too large or missing");

            try
            {
                int projectId = file.ProjectId;
                int taskId = file.TaskId;
                var uploadPath = Path.Combine("Upload",projectId.ToString(),taskId.ToString());
                var fileFullPath = Path.Combine(uploadPath,file.FileData.FileName);

                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);

                using (FileStream fs = new FileStream(fileFullPath, FileMode.CreateNew, FileAccess.Write))
                {
                    var stream = new MemoryStream();
                    file.FileData.CopyTo(stream);
                    fs.Write(stream.ToArray(), 0, (int)file.FileData.Length);
                    fs.Close();
                }

                if (File.Exists(fileFullPath))
                    return Response<bool>.Succeeded(true);
                else
                    return Response<bool>.Failed("Error: file disappeared");
            }
            catch (Exception)
            {
                return Response<bool>.Failed("Internal error");
            }
        }
    }
}
