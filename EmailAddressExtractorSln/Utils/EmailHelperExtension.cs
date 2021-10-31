using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EmailAddressExtractorSln.Utils
{
    public static class EmailHelperExtension
    {
        public static HashSet<string> GetEmailFromDoc(string text)
        {
            const string MatchEmailPattern =
              @"(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
              + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
              + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
              + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})";

            Regex rx = new Regex(
              MatchEmailPattern,
              RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // Find matches.
            MatchCollection matches = rx.Matches(text);

            var result = new HashSet<string>();

            // Report on each match.
            foreach (Match match in matches)
            {
                result.Add(match.Value.ToLower());
            }

            return result;
        }
    }
}
