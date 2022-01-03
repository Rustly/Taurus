using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Taurus.Commands.Parsers
{
    internal static class TimeParser
    {
        private delegate TimeSpan CallBackDelegate(string match);

        private static readonly Dictionary<string, CallBackDelegate> _callBackResult;

        private static readonly Regex _regex = new(@"(\d*)\s*([a-zA-Z]*)\s*(?:and|,)?\s*");

        static TimeParser() 
            => _callBackResult = new()
            {
                { "second", Seconds },
                { "seconds", Seconds },
                { "sec", Seconds },
                { "s", Seconds },
                { "minute", Minutes },
                { "minutes", Minutes },
                { "min", Minutes },
                { "m", Minutes },
                { "hour", Hours },
                { "hours", Hours },
                { "h", Hours },
                { "day", Days },
                { "days", Days },
                { "d", Days },
                { "week", Weeks },
                { "weeks", Weeks },
                { "w", Weeks },
                { "month", Months },
                { "months", Months },
            };

        private static TimeSpan Seconds(string match)
            => new(0, 0, int.Parse(match));

        private static TimeSpan Minutes(string match)
            => new(0, int.Parse(match), 0);

        private static TimeSpan Hours(string match)
            => new(int.Parse(match), 0, 0);

        private static TimeSpan Days(string match)
            => new(int.Parse(match), 0, 0, 0);

        private static TimeSpan Weeks(string match)
            => new((int.Parse(match) * 7), 0, 0, 0);

        private static TimeSpan Months(string match)
            => new((int.Parse(match) * 30), 0, 0, 0);

        public static DateTime ParseDateTime(string s)
        {
            if (!DateTime.TryParse(s, out DateTime time))
            {
                time = DateTime.Now;
            }
            return time;
        }

        public static TimeSpan ParseTimeSpan(string s)
        {
            if (!TimeSpan.TryParse(s, out TimeSpan span))
            {
                s = s.ToLower().Trim();
                MatchCollection matches = _regex.Matches(s);
                if (matches.Any())
                    foreach (Match match in matches)
                    {
                        if (_callBackResult.TryGetValue(match.Groups[2].Value, out var callback))
                            span += callback(match.Groups[1].Value);
                        else continue;
                    }
            }
            return span;
        }
    }
}
