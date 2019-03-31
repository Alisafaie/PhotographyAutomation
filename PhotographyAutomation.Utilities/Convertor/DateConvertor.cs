using System;
using System.Globalization;
using System.Text;

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
            var dt = new DateTime(year, month, day, pc);
            return dt;
        }

        public static string ToShamsiDate(this DateTime value)
        {
            var pc = new PersianCalendar();
            var sb = new StringBuilder();
            sb.Append(pc.GetYear(value).ToString("0000"));
            sb.Append("/");
            sb.Append(pc.GetMonth(value).ToString("00"));
            sb.Append("/");
            sb.Append(pc.GetDayOfMonth(value).ToString("00"));

            return sb.ToString();
        }

        public static string ToShamsiDateRevesed(this DateTime value)
        {
            var pc = new PersianCalendar();
            var sb = new StringBuilder();

            sb.Append(pc.GetDayOfMonth(value).ToString("00"));
            sb.Append("/");
            sb.Append(pc.GetMonth(value).ToString("00"));
            sb.Append("/");
            sb.Append(pc.GetYear(value).ToString("0000"));

            var returnValue = sb.ToString();
            sb.Clear();
            return returnValue;
        }

        public static string ToShortTimeString(this TimeSpan value)
        {
            var sb = new StringBuilder();
            sb.Append(value.Hours.ToString("00"));
            sb.Append(":");
            sb.Append(value.Minutes.ToString("00"));
            sb.Append(" ");
            sb.Append(value.Hours >= 12 ? "PM" : "AM");
            return sb.ToString();
        }
    }
}
