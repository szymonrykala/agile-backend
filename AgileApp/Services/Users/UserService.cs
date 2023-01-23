using AgileApp.Enums;
using AgileApp.Models;
using AgileApp.Models.Requests;
using AgileApp.Repository.Users;
using AgileApp.Utils;

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

        public async Task<AuthorizeUserResult> AuthorizeUser(AuthorizationDataRequest request)
        {
            try
            {
                var requestedUser = _userRepository
                    .GetAllUsers(u => request.Email == u.Email && request.Password == u.Password)
                    .FirstOrDefault();

                return requestedUser != null
                    ? AuthorizeUserResult.Exist(requestedUser.Hash)
                    : AuthorizeUserResult.NotExist();
            }
            catch (Exception ex)
            {
                //_logger.LogCritical(ex.ToString());
                return new AuthorizeUserResult();
            }
        }

        public List<UserResponse> GetAllUsers()
        {
            var response = new List<UserResponse>();
            var usersDb = _userRepository.GetAllUsers(u => u.Role == UserRoleEnum.Student || u.Role == UserRoleEnum.Professor).ToList();

            foreach (var user in usersDb)
                response.Add(new UserResponse { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Role = user.Role });

            return response;
        }

        public string AddUser(AuthorizationDataRequest request)
        {
            try
            {
                string clientHash = Guid.NewGuid().ToString();

                int affectedRows = _userRepository.AddNewUser(new Repository.Models.UserDb
                {
                    Email = request.Email,
                    Password = request.Password,
                    Hash = clientHash,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Role = (UserRoleEnum)request.Role
                });

                return affectedRows == 1
                    ? clientHash
                    : "";
            }
            catch (Exception ex)
            {
                //_logger.LogCritical(ex.ToString());
                return "";
            }
        }

        public bool DeleteUser(int id) => _userRepository.DeleteUser(id) == 1;

        public UserResponse GetUserByEmail(string email)
        {
            var response = new UserResponse();
            var userDb = _userRepository.GetUserByEmail(email);

            if (userDb != null)
            {
                response.FirstName = userDb.FirstName;
                response.LastName = userDb.LastName;
                response.Email = userDb.Email;
            }

            return response;
        }

        public UserResponse GetUserById(int id)
        {
            var response = new UserResponse();
            var userDb = _userRepository.GetUserById(id);

            if (userDb != null)
            {
                response.FirstName = userDb.FirstName;
                response.LastName = userDb.LastName;
                response.Email = userDb.Email;
            }

            return response;
        }

        public UserResponse GetUserByName(string userName)
        {
            var response = new UserResponse();
            var userDb = _userRepository.GetUserByName(userName);

            if (userDb != null)
            {
                response.FirstName = userDb.FirstName;
                response.LastName = userDb.LastName;
                response.Email = userDb.Email;
            }

            return response;
        }

        public bool UpdateUser(UpdateUserRequest user)
        {
            var dbUser = _userRepository.GetUserById(user.Id);

            dbUser.FirstName = dbUser.FirstName.UserStringCompare(user.FirstName);
            dbUser.LastName = dbUser.LastName.UserStringCompare(user.LastName);
            dbUser.Email = dbUser.Email.UserStringCompare(user.Email);

            dbUser.Password = dbUser.Password.UserStringCompare(user.Password);
            dbUser.Role = (UserRoleEnum)(user.Role != dbUser.Role ? user.Role : dbUser.Role);

            return _userRepository.UpdateUser(dbUser) == 1;
        }

        public bool IsEmailTaken(string email)
        {
            try
            {
                return _userRepository.IsEmailAlreadyUsed(email);
            }
            catch (Exception ex)
            {
                //_logger.LogCritical(ex.ToString());
                return false;
            }
        }
    }
}
