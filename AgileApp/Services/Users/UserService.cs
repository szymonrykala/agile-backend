using AgileApp.Enums;
using AgileApp.Models;
using AgileApp.Repository.Users;

namespace AgileApp.Services.Users
{
    public class UserService : IUserService
    {
        //private readonly ILogger _logger;
        private readonly IUserRepository _userRepository;

        public UserService(
            //ILogger logger,
            IUserRepository userRepository)
        {
            //_logger = logger;
            _userRepository = userRepository;
        }

        public List<UserResponse> GetAllUsers()
        {
            var response = new List<UserResponse>();
            var usersDb = _userRepository.GetAllUsers(u => u.Role == UserRoleEnum.Student || u.Role == UserRoleEnum.Professor).ToList();

            foreach (var user in usersDb)
                response.Add(new UserResponse { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Role = user.Role });

            return response;
        }

        public bool AddUser(UserResponse newUser)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public UserResponse GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public UserResponse GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public UserResponse GetUserByName(string userName)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(UserResponse user)
        {
            throw new NotImplementedException();
        }
    }
}
