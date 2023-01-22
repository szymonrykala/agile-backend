namespace AgileApp.Models
{
    public class AuthorizeClientResult
    {
        public bool Exists { get; set; }

        public string Hash { get; set; }

        public static AuthorizeClientResult NotExist() => new AuthorizeClientResult { Exists = false };

        public static AuthorizeClientResult Exist(string hash) => new AuthorizeClientResult { Exists = true, Hash = hash };
    }
}
