using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCServer.Common.Helpers
{
    public static class DateTimeHelper
    {
        public static string GetISOStandardDateTime(this DateTime? value)
        {
            string dateTime = string.Empty;

            if (value.HasValue)
                dateTime = value.Value.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

            return dateTime;
        }

        public static string GetISOStandardDateTime(this DateTime value)
        {
            return value.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        }
    }
}
