﻿using AgileApp.Models.Common;
using AgileApp.Models.Projects;
using AgileApp.Repository.Projects;
using AgileApp.Utils;

namespace AgileApp.Services.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(
            IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public bool DeleteProject(int id) => _projectRepository.DeleteProject(id) == 1;

        public List<ProjectResponse> GetAllProjects()
        {
            var response = new List<ProjectResponse>();
            var projectsDb = _projectRepository.GetAllProjects(p => !string.IsNullOrWhiteSpace(p.Name)).ToList();

            foreach (var project in projectsDb)
                response.Add(new ProjectResponse { Name = project.Name, Description = project.Description });

            return response;
        }

        public string AddNewProject(AddProjectRequest project)
        {
            try
            {
                int affectedRows = _projectRepository.AddNewProject(new Repository.Models.ProjectDb
                {
                    Name = project.Name,
                    Description = project.Description
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

        public ProjectResponse GetProjectById(int id)
        {
            var response = new ProjectResponse();
            var userDb = _projectRepository.GetProjectById(id);

            if (userDb != null)
            {
                response.Name = userDb.Name;
                response.Description = userDb.Description;
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
