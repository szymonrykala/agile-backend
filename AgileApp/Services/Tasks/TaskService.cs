using AgileApp.Models.Tasks;
using AgileApp.Repository.Tasks;
using AgileApp.Utils;

namespace AgileApp.Services.Tasks
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(
            ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public bool DeleteTask(int id) => _taskRepository.DeleteTask(id) == 1;

        public List<TaskResponse> GetAllTasks()
        {
            var response = new List<TaskResponse>();
            var tasksDb = _taskRepository.GetAllTasks(p => string.IsNullOrWhiteSpace(p.Name)).ToList();

            foreach (var task in tasksDb)
                response.Add(new TaskResponse { Name = task.Name, Description = task.Description });

            return response;
        }

        public string AddNewTask(AddTaskRequest task)
        {
            try
            {
                int affectedRows = _taskRepository.AddNewTask(new Repository.Models.TaskDb
                {
                    Name = task.Name,
                    Description = task.Description
                });

                return affectedRows == 1
                    ? "true"
                    : "false";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public TaskResponse GetTaskById(int id)
        {
            var response = new TaskResponse();
            var userDb = _taskRepository.GetTaskById(id);

            if (userDb != null)
            {
                response.Name = userDb.Name;
                response.Description = userDb.Description;
            }

            return response;
        }

        public TaskResponse GetTaskByName(string name)
        {
            var response = new TaskResponse();
            var userDb = _taskRepository.GetTaskByName(name);

            if (userDb != null)
            {
                response.Name = userDb.Name;
                response.Description = userDb.Description;
            }

            return response;
        }

        public bool UpdateTask(UpdateTaskRequest task)
        {
            var dbTask = _taskRepository.GetTaskById(task.Id);

            dbTask.Name = dbTask.Name.UserStringCompare(task.Name);
            dbTask.Description = dbTask.Description.UserStringCompare(task.Description);

            return _taskRepository.UpdateTask(dbTask) == 1;
        }
    }
}
