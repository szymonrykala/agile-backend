using AgileApp.Models.Projects;
using AgileApp.Models.Requests;

namespace AgileApp.Services.Projects
{
    public interface IProjectService
    {
        public List<ProjectResponse> GetAllProjects();

        string AddNewProject(AddProjectRequest project);

        ProjectResponse GetProjectById(int id);

        ProjectResponse GetProjectByName(string name);

        bool UpdateProject(UpdateProjectRequest project);

        bool DeleteProject(int id);
    }
}
