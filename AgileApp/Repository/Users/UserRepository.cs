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

        public bool IsEmailAlreadyUsed(string email) => UserEntities.Any(u => u.Email == email);

        public int AddNewUser(UserDb user)
        {
            _dbContext.Users.Add(user);
            return _dbContext.SaveChanges();
        }
    }
}
