using AgileApp.Repository.Models;

namespace AgileApp.Repository.Users
{
    public interface IUserRepository
    {
        public IEnumerable<UserDb> GetAllUsers(Func<UserDb, bool> predicate);

    }
}
