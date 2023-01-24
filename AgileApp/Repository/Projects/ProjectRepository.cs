using AgileApp.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace AgileApp.Repository.Projects
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AgileDbContext _dbContext;
        private IQueryable<ProjectDb> ProjectEntities => _dbContext.Projects.AsNoTracking();

        public ProjectRepository(AgileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ProjectDb> GetAllProjects(Func<ProjectDb, bool> predicate) => ProjectEntities.Where(predicate).ToList();

        public ProjectDb GetProjectById(int id) => ProjectEntities.FirstOrDefault(p => p.Id == id);

        public ProjectDb GetProjectByName(string name) => ProjectEntities.FirstOrDefault(
            p => p.Name.Contains(name) || p.Description.Contains(name));

        public int AddNewProject(ProjectDb project)
        {
            _dbContext.Projects.Add(project);
            return _dbContext.SaveChanges();
        }

        public int DeleteProject(int id)
        {
            var projectOld = _dbContext.Projects.FirstOrDefault(p => p.Id == id);
            if (projectOld != null)
            {
                _dbContext.Projects.Remove(projectOld);
                return _dbContext.SaveChanges();
            }

            return 0;
        }

        public int UpdateProject(ProjectDb project)
        {
            var projectToUpdate = _dbContext.Projects.FirstOrDefault(p => p.Id == project.Id);
            if (projectToUpdate != null)
            {
                projectToUpdate.Name = project.Name;
                projectToUpdate.Description = project.Description;

                return _dbContext.SaveChanges();
            }

            return 0;
        }
    }
}
