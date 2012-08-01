using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Orchard.Patrocinadores
{
    public static class Extensions
    {
        public static int WeekNumber(this System.DateTime value)
        {
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(value, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }

        public static string ToStringFormated(this System.DateTime value)
        {
            return value.ToString("yyyy-MM-dd");
        }
    }
}