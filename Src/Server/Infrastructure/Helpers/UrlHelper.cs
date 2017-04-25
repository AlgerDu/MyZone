using System.Text.RegularExpressions;

namespace MyZone.Server.Infrastructure.Helpers
{
    /// <summary>
    /// 对 Url 操作的一些帮助
    /// </summary>
    public static class UrlHelper
    {
        /// <summary>
        /// 检测字符串是不是正确的 Url
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUrl(string str)
        {
            try
            {
                string Url = @"^http[s]?://[^/:]+(:\d*)?";
                return Regex.IsMatch(str, Url);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取 Url 的主机地址
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetHost(string url)
        {
            var array = Regex.Split(url, @"(^http[s]?://[^/:]+(:\d*)?)");
            return array[1];
        }

        /// <summary>
        /// 获取 Url 的相对路径
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetPath(string url)
        {
            var array = Regex.Split(url, @"(^http[s]?://[^/:]+(:\d*)?)");

            if (array.Length < 3)
            {
                return "/";
            }
            else
            {
                return array[2];
            }
        }
    }
}