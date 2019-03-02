using System;
using System.Globalization;

namespace PhotographyAutomation.Utilities.Convertor
{
    public static class DateConvertor
    {
        public static DateTime? ToMiladiDate(this string value)
        {
            var pc = new PersianCalendar();

            if (!int.TryParse(value.Substring(0, 4), out var year)) return null;
            if (!int.TryParse(value.Substring(5, 2), out var month)) return null;
            if (!int.TryParse(value.Substring(8, 2), out var day)) return null;
            var dt = new DateTime(year, month,day, pc);
            return dt;
        }

        public static string ToShamsiDate(this DateTime value)
        {
            var pc=new PersianCalendar();
            return pc.GetYear(value).ToString("0000") + "/" + 
                   pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00");
        }
    }
}
