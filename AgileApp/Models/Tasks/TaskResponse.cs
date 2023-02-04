using AgileApp.Enums;

namespace AgileApp.Models.Tasks
{
    public class TaskResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; } 

        public int UserId { get; set; }

        public int ProjectId { get; set; }
    }
}
