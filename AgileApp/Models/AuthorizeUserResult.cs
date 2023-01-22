namespace AgileApp.Models
{
    public class AuthorizeUserResult
    {
        public bool Exists { get; set; }

        public string Hash { get; set; }

        public static AuthorizeUserResult NotExist() => new AuthorizeUserResult { Exists = false };

        public static AuthorizeUserResult Exist(string hash) => new AuthorizeUserResult { Exists = true, Hash = hash };
    }
}
