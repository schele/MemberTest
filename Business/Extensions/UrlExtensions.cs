namespace MembersTestUmbraco16.Business.Extensions
{
    public static class UrlExtensions
    {
        public static string GetAbsolutePath(this string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return string.Empty;

            var uri = new Uri(url, UriKind.RelativeOrAbsolute);
            var path = uri.IsAbsoluteUri ? uri.AbsolutePath : url;

            if (!path.StartsWith("/"))
                path = "/" + path;

            return path;
        }
    }
}