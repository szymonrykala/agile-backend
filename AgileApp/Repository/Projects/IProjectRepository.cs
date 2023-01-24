using AgileApp.Repository.Models;

namespace AgileApp.Repository.Projects
{
    public interface IProjectRepository
    {
        public IEnumerable<ProjectDb> GetAllProjects(Func<ProjectDb, bool> predicate);

        int AddNewProject(ProjectDb project);

        ProjectDb GetProjectById(int id);

        ProjectDb GetProjectByName(string name);

        int UpdateProject(ProjectDb project);

        int DeleteProject(int id);
    }
}
