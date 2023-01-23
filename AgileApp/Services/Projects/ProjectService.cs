using AgileApp.Models.Projects;
using AgileApp.Models.Requests;
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
            var projectsDb = _projectRepository.GetAllProjects(p => string.IsNullOrWhiteSpace(p.Name)).ToList();

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
            var dbProject = _projectRepository.GetProjectById(project.Id);

            dbProject.Name = dbProject.Name.UserStringCompare(project.Name);
            dbProject.Description = dbProject.Description.UserStringCompare(project.Description);

            return _projectRepository.UpdateProject(dbProject) == 1;
        }
    }
}
