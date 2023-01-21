using Microsoft.EntityFrameworkCore;
using AgileApp.Repository.Models;

namespace AgileApp.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AgileDbContext _dbContext;
        private IQueryable<Models.UserDb> UserEntities => _dbContext.Users.AsNoTracking();

        public UserRepository(AgileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<UserDb> GetAllUsers(Func<UserDb, bool> predicate) => UserEntities.Where(predicate).ToList();

    }
}
