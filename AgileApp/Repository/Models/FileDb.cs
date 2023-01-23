namespace AgileApp.Repository.Models
{
    public class FileDb
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public DateTime ModificationDate { get; set; }

        public int UserId { get; set; }

        public int ProjectId { get; set; }

        public int TaskId { get; set; }
    }
}
