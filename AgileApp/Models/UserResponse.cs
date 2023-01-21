using AgileApp.Enums;

namespace AgileApp.Models
{
    public class UserResponse
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public UserRoleEnum Role { get; set; }


    }
}
