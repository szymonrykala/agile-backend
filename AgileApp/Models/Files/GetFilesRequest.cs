namespace AgileApp.Models.Files
{
    public class GetFilesRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public string UserId { get; set; }

        public DateTime ModificationDate { get; set; }


    }
}
