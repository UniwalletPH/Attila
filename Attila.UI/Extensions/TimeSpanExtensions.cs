using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI
{
    public static class TimeSpanExtensions
    {
        public static string GetTimeString(this TimeSpan ts)
        {
            return new DateTime().AddMinutes(ts.TotalMinutes).ToString("hh:mm tt");
        }
    }
}
