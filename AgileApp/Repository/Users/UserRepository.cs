﻿using Microsoft.EntityFrameworkCore;
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

        public UserDb GetUserById(int id) => UserEntities.FirstOrDefault(u => u.Id == id);

        public UserDb GetUserByName(string name) => UserEntities.FirstOrDefault(
            u => u.FirstName.Contains(name) || u.LastName.Contains(name));

        public UserDb GetUserByEmail(string email) => UserEntities.FirstOrDefault(u => u.Email == email);

        public bool IsEmailAlreadyUsed(string email) => UserEntities.Any(u => u.Email == email);

        public int AddNewUser(UserDb user)
        {
            _dbContext.Users.Add(user);
            return _dbContext.SaveChanges();
        }

        public int UpdateUser(UserDb user)
        {
            var userToUpdate = _dbContext.Users.FirstOrDefault(u => u.Id == user.Id);
            if (userToUpdate != null)
            {
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.LastName = user.LastName;
                userToUpdate.Email = user.Email;

                userToUpdate.Password = user.Password;
                userToUpdate.Role = user.Role;

                return _dbContext.SaveChanges();
            }

            return 0;
        }

        public int DeleteUser(int id)
        {
            var userOld = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (userOld != null)
            {
                _dbContext.Users.Remove(userOld);
                return _dbContext.SaveChanges();
            }

            return 0;
        }
    }
}
