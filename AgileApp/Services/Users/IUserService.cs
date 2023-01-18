using AgileApp.Models;

namespace AgileApp.Services.Users
{
    public interface IUserService
    {
        //response may be changed after the design!!!
        public List<UserResponse> GetAllUsers();

        public UserResponse GetUserById(int id);

        public UserResponse GetUserByName(string userName);

        public UserResponse GetUserByEmail(string email);

        public bool AddUser(UserResponse newUser);

        public bool UpdateUser(UserResponse user);

        public bool DeleteUser(int id);
    }
}
