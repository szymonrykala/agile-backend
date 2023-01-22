namespace AgileApp.Utils
{
    public static class StringExtensions
    {
        public static string UserStringCompare(this string s, string newProperty)
        {
            if (newProperty != null && !string.IsNullOrWhiteSpace(newProperty) && newProperty != s)
                return newProperty;
            return s;
        }
    }
}
