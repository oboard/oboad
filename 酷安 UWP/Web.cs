﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
using System.Text.RegularExpressions;
using Windows.Networking.BackgroundTransfer;

namespace 酷安_UWP
{
    class Web
    {

        public static async Task<string> GetHttp(string url)
        {
            try
            {
                return await new HttpClient().GetStringAsync(new Uri(url));
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static String ReplaceHtml(String str)
        {
            //换行和段落
            String s = str.Replace("<br>", "\n").Replace("<br>", "\n").Replace("<br/>", "\n").Replace("<br />", "\n").Replace("<p>", "").Replace("</p>", "\n").Replace("&nbsp;", " ");
            //链接彻底删除！
            try
            {
                while (s.IndexOf("<a") > 0)
                {
                    s = s.Replace(@"<a href=""" + Regex.Split(Regex.Split(s, @"<a href=""")[1], @""">")[0] + @""">", "");
                    s = s.Replace("</a>", "");
                }
            }
            catch (Exception)
            {

            }
            return s;
        }
        
    }
}
