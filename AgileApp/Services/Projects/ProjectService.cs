﻿using AgileApp.Models.Common;
using AgileApp.Models.Projects;
using AgileApp.Repository.Projects;
using AgileApp.Repository.Users;
using AgileApp.Services.Files;
using AgileApp.Services.Tasks;
using AgileApp.Utils;

namespace AgileApp.Services.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITaskService _taskService;
        private readonly IFileService _fileService;

        public ProjectService(
            IProjectRepository projectRepository,
            IUserRepository userRepository,
            ITaskService taskService,
            IFileService fileService)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _taskService = taskService;
            _fileService = fileService;
        }

        public bool DeleteProject(int id)
        {
            var tasks = _taskService.GetAllTasks().Where(t => t.ProjectId == id);
            if (tasks.Count() > 0)
                foreach (var task in tasks)
                {
                    _taskService.DeleteTask(task.Id);
                }

            return _projectRepository.DeleteProject(id) == 1;
        }

        public List<ProjectResponse> GetAllProjects()
        {
            var response = new List<ProjectResponse>();
            var projectsDb = _projectRepository.GetAllProjects(p => !string.IsNullOrWhiteSpace(p.Name)).ToList();

            foreach (var project in projectsDb)
                response.Add(new ProjectResponse { Id = project.Id, Name = project.Name, Description = project.Description, Users = _userRepository.GetAllUsersOnProject(project.Id).ToList() });

            return response;
        }

        public Response<int> AddNewProject(AddProjectRequest project)
        {
            try
            {
                int newProjectId= _projectRepository.AddNewProject(new Repository.Models.ProjectDb
                {
                    Name = project.Name,
                    Description = project.Description
                });

                return newProjectId > 0
                    ? Response<int>.Succeeded(newProjectId)
                    : Response<int>.Failed("Cannot obtain project Id");
            }
            catch (Exception ex)
            {
                return Response<int>.Failed(ex.Message);
            }
        }

        public ProjectResponse GetProjectById(int id)
        {
            var response = new ProjectResponse();
            var projectDb = _projectRepository.GetProjectById(id);

            if (projectDb != null)
            {
                response.Id = projectDb.Id;
                response.Name = projectDb.Name;
                response.Description = projectDb.Description;
                response.Users = _userRepository.GetAllUsersOnProject(id).ToList();
            }

            return response;
        }

        public ProjectResponse GetProjectByName(string name)
        {
            var response = new ProjectResponse();
            var userDb = _projectRepository.GetProjectByName(name);

            if (userDb != null)
            {
                response.Name = userDb.Name;
                response.Description = userDb.Description;
            }

            return response;
        }

        public bool UpdateProject(UpdateProjectRequest project)
        {
            try
            {
                var dbProject = _projectRepository.GetProjectById(project.Id);

                dbProject.Name = dbProject.Name.PropertyStringCompare(project.Name);
                dbProject.Description = dbProject.Description.PropertyStringCompare(project.Description);

                return _projectRepository.UpdateProject(dbProject) == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Response AddUserToProject(ProjectUserRequest request)
        {
            try
            {
                if (_projectRepository.GetProjUserTable(p => p.Project_Id == request.ProjectId && p.User_Id == request.UserId).ToList().Count == 0)
                    return _projectRepository.AddUserToProject(request) ? new Response { IsSuccess = true } : new Response { IsSuccess = false, Error = "Altered records different than 1" };
                else return new Response { IsSuccess = false, Error = "User already exists in the project" };
            }
            catch (Exception)
            {
                return new Response { IsSuccess = false, Error = "Check the number of users in the db" };
            }
        }

        public Response RemoveUserFromProject(ProjectUserRequest request)
        {
            try
            {
                if (_projectRepository.GetProjUserTable(p => p.Project_Id == request.ProjectId && p.User_Id == request.UserId).ToList().Count == 1)
                    return _projectRepository.RemoveUserFromProject(request) ? new Response { IsSuccess = true } : new Response { IsSuccess = false, Error = "Altered records different than 1" };
                else return new Response { IsSuccess = false, Error = "User does not exist in the project" };
            }
            catch (Exception)
            {
                return new Response { IsSuccess = false, Error = "Check the number of users in the db" };
            }
        }
    }
}
