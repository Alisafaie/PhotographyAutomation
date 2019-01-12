using System;
using System.Globalization;

namespace PhotographyAutomation.Utilities.Convertor
{
    public static class DateConvertor
    {
        public static DateTime ToMiladiDate(this string value)
        {
            PersianCalendar pc = new PersianCalendar();

            string year = value.Substring(0, 4);
            string month = value.Substring(5, 2);
            string day = value.Substring(8, 2);
            DateTime dt = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day), pc);
            return dt;

        }

        public static string ToShamsiDate(this DateTime value)
        {
            PersianCalendar pc=new PersianCalendar();
            return pc.GetYear(value).ToString("0000") + "/" + 
                   pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00");
        }
    }
}
