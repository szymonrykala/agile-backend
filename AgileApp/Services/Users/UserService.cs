using AgileApp.Enums;
using AgileApp.Models;
using AgileApp.Models.Requests;
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

        public async Task<AuthorizeClientResult> AuthorizeUser(AuthorizationDataRequest request)
        {
            try
            {
                var requestedUser = _userRepository
                    .GetAllUsers(u => request.Email == u.Email && request.Password == u.Password)
                    .FirstOrDefault();

                return requestedUser != null
                    ? AuthorizeClientResult.Exist(requestedUser.Hash)
                    : AuthorizeClientResult.NotExist();
            }
            catch (Exception ex)
            {
                //_logger.LogCritical(ex.ToString());
                return new AuthorizeClientResult();
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
