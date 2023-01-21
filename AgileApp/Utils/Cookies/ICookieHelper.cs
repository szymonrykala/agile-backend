using AgileApp.Models.Common;
using AgileApp.Models.Jwt;

namespace AgileApp.Utils.Cookies
{
    public interface ICookieHelper
    {
        void AddJwtToHttpOnlyResponseCookie(HttpContext context, string email, string hash);

        JwtReverseResult ReverseJwtFromRequest(HttpContext context);

        Response InvalidateJwtCookie(HttpContext context);
    }
}
