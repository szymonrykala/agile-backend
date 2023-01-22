using AgileApp.Models;
using AgileApp.Models.Requests;

namespace AgileApp.Services.Users
{
    public interface IUserService
    {
        Task<AuthorizeUserResult> AuthorizeUser(AuthorizationDataRequest request);

        //response may be changed after the design!!!
        public List<UserResponse> GetAllUsers();

        public UserResponse GetUserById(int id);

        public UserResponse GetUserByName(string userName);

        public UserResponse GetUserByEmail(string email);

        public string AddUser(AuthorizationDataRequest request);

        public bool UpdateUser(UpdateUserRequest user);

        public bool DeleteUser(int id);

        public bool IsEmailTaken(string email);
    }
}
