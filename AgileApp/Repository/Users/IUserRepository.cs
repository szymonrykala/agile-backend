﻿using AgileApp.Repository.Models;

namespace AgileApp.Repository.Users
{
    public interface IUserRepository
    {
        public IEnumerable<UserDb> GetAllUsers(Func<UserDb, bool> predicate);

        bool IsEmailAlreadyUsed(string email);

        int AddNewUser(UserDb user);

        UserDb GetUserById(int id);

        UserDb GetUserByName(string name);

        UserDb GetUserByEmail(string email);

        int UpdateUser(UserDb user);

        int DeleteUser(int id);
    }
}
