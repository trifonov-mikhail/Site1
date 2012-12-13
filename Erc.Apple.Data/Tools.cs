using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Erc.Apple.Data
{
    public static class Tools
    {
        public static string FixUrl(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                url = url.Trim();
                if (!url.ToLower().StartsWith("http") && url != "#")
                {
                    return string.Format("http://{0}",url);
                }
            }
            return url;
        }
        public static bool CheckEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;
            Regex ex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            return ex.IsMatch(email);
        }
    }
}
