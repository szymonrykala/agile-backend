﻿using AgileApp.Enums;
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
            var tasksDb = _taskRepository.GetAllTasks(p => !string.IsNullOrWhiteSpace(p.Name)).ToList();

            foreach (var task in tasksDb)
                response.Add(new TaskResponse { Name = task.Name, Description = task.Description, Status = task.Status });

            return response;
        }

        public string AddNewTask(AddTaskRequest task)
        {
            try
            {
                int affectedRows = _taskRepository.AddNewTask(new Repository.Models.TaskDb
                {
                    Name = task.Name,
                    UserId = task.UserId,
                    Status = task.Status,
                    ProjectId = task.ProjectId,
                    Description = task.Description,
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
                response.Status = userDb.Status;
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
                response.Status = userDb.Status;
                response.Description = userDb.Description;
            }

            return response;
        }

        public bool UpdateTask(UpdateTaskRequest task)
        {
            try
            {
                var dbTask = _taskRepository.GetTaskById(task.Id);

                dbTask.Name = dbTask.Name.PropertyStringCompare(task.Name);
                dbTask.Description = dbTask.Description.PropertyStringCompare(task.Description);

                dbTask.UserId = task.UserId != null && task.UserId > 0 ? (int)task.UserId : dbTask.UserId;
                dbTask.ProjectId = task.ProjectId != null && task.ProjectId > 0 ? (int)task.ProjectId : dbTask.ProjectId;
                dbTask.Status = task.Status != null && task.Status != dbTask.Status ? (UserTaskStatus)task.Status : dbTask.Status;

                return _taskRepository.UpdateTask(dbTask) == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
