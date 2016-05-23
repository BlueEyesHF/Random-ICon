using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


    class Icon
    {
        private void changeico()
        {
            List<string> icon = new List<string>();
            char[] lettre = "AZERTYUIOPQSDFGHJKLMWXCVBN?1234567890azertyuiopqsdfghjklmwxcvbn".ToArray();
            string req = new WebClient().DownloadString("https://www.iconfinder.com/search/?q=" + lettre[new Random().Next(0, lettre.Length)] + "&price=free&style=ico");
            MatchCollection matches = Regex.Matches(req, "href=\"/icons/([0-9]+)", RegexOptions.Multiline);
            foreach (Match match in matches)
            {
                foreach (Capture capture in match.Captures)
                {
                    icon.Add(capture.Value);
                }
            }
            new WebClient().DownloadFile("https://www.iconfinder.com" + icon[new Random().Next(0, icon.Count - 1)].Replace("href=\"", "") + "/download/ico", "Icon.ico");
        }
    }
