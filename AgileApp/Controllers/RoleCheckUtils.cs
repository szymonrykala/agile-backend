using AgileApp.Enums;

namespace AgileApp.Controllers
{
    public class RoleCheckUtils
    {
        public static bool IsAdmin(Models.Jwt.JwtReverseResult reverseTokenResult)
        {
            int adminRole = (int)UserRoleEnum.ADMIN;
            return reverseTokenResult.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.Role)?.Value == adminRole.ToString();
        }

        public static UserRoleEnum CheckUserRole(Models.Jwt.JwtReverseResult reverseTokenResult)
        {
            UserRoleEnum userRoleResponse = UserRoleEnum.None;

            if (reverseTokenResult == null)
                return userRoleResponse;

            string userRole = reverseTokenResult.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.Role)?.Value;

            if (string.IsNullOrWhiteSpace(userRole))
                return userRoleResponse;

            try
            {
                int role = 0;
                int.TryParse(userRole, out role);
                userRoleResponse = (UserRoleEnum)role;
            }
            catch (Exception)
            {
                return UserRoleEnum.None;
            }

            return userRoleResponse;
        }
    }
}
