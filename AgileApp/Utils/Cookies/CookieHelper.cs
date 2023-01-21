using AgileApp.Models.Common;
using AgileApp.Models.Jwt;
using AgileApp.Utils.Authorization;

namespace AgileApp.Utils.Cookies
{
    public class CookieHelper : ICookieHelper
    {
        private readonly IJwtHelper _jwtHelper;

        public CookieHelper(IJwtHelper jwtHelper)
        {
            _jwtHelper = jwtHelper;
        }

        public void AddJwtToHttpOnlyResponseCookie(HttpContext context, string email, string hash)
        {
            string jwtToken = _jwtHelper.GenerateTokenFromLoginData(email, hash);
            context.Response.Cookies.Append(AppSettings.JwtCookieKey,
                jwtToken,
                new CookieOptions
                {
                    Secure = true,
                    HttpOnly = true,
                    Expires = DateTimeOffset.UtcNow.AddMonths(AppSettings.ValidCookieMonthsAmount),
                    SameSite = SameSiteMode.None
                });
        }

        public Response InvalidateJwtCookie(HttpContext context)
        {
            try
            {
                bool hasToken = context.Request.Cookies.ContainsKey(AppSettings.JwtCookieKey);

                if (!hasToken)
                {
                    return Response.Succeeded();
                }

                DeleteCookie(context, AppSettings.JwtCookieKey);
                return Response.Succeeded();
            }
            catch (Exception ex)
            {
                //_logger.LogCritical(ex.ToString());
                return Response.Failed();
            }
        }

        public JwtReverseResult ReverseJwtFromRequest(HttpContext context)
        {
            bool hasToken = context.Request.Cookies.TryGetValue(AppSettings.JwtCookieKey, out string jwtToken);

            if (!hasToken || string.IsNullOrWhiteSpace(jwtToken))
            {
                return JwtReverseResult.Invalid();
            }

            return _jwtHelper.ReverseTokenContent(jwtToken);
        }

        private void DeleteCookie(HttpContext context, string key)
        {
            context.Response.Cookies.Delete(key,
                new CookieOptions
                {
                    Secure = true,
                    HttpOnly = true,
                    SameSite = SameSiteMode.None
                });
        }
    }
}
