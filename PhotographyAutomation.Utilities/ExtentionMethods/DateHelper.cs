using FreeControls;
using System;
using System.Globalization;

namespace PhotographyAutomation.Utilities.ExtentionMethods
{
    public static class DateHelper
    {
        public static DateTime GetFirstDayOfWeek(this DateTime date)
        {
            while (true)
            {
                if (date.DayOfWeek == DayOfWeek.Saturday)
                    return date;
                date = date.AddDays(-1);
            }
        }


        public static DateTime GetFridayDate(this DateTime now)
        {
            while (true)
            {
                if (now.DayOfWeek == DayOfWeek.Friday) return now;

                now = now.AddDays(1);
            }
        }


        public static DateTime GetFirstDayOfMonth(this PersianDate date)
        {
            PersianCalendar pc = new PersianCalendar();
            int currentDayOfMonth = pc.GetDayOfMonth(date);
            return date.AddDays(-currentDayOfMonth + 1);
        }


        public static DateTime GetLastDateOfMonth(this PersianDate date)
        {
            PersianCalendar pc = new PersianCalendar();

            int totalDayInCurrentMonth = pc.GetDaysInMonth(date.Year, date.Month);
            int currentDayOfMonth = pc.GetDayOfMonth(date);
            int delta = totalDayInCurrentMonth - currentDayOfMonth;
            DateTime dtTo = DateTime.Now.AddDays(delta);
            return dtTo;
        }


        public static DateTime GetDateFromPersianDateTimePicker(this PersianDate selectedDate)
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime dtSelectedDate = pc.ToDateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 0, 0, 0, 0);
            return dtSelectedDate;
        }

        public static DateTime GetBeggingOfTheDateTime(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
        }

        public static DateTime GetEndOfTheDateTime(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
        }
    }
}
