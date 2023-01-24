using AgileApp.Enums;

namespace AgileApp.Models.Tasks
{
    public class TaskResponse
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public UserTaskStatus Status { get; set; } 
    }
}
