using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNews.Utility.Optimization
{
    public static class Search
    {
        public static string ToNoSpaceAndLower(this string text)
        {
            return text.Replace(" ", "").ToLower();
        }
    }
}
