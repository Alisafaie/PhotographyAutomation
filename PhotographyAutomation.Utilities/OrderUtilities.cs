using System;
using System.Globalization;
using System.Text;

namespace PhotographyAutomation.Utilities
{
    public static class OrderUtilities
    {
        public static string GenerateOrderCode(DateTime dt, int customerId, int bookingId)
        {
            var pc = new PersianCalendar();
            var persianYear = pc.GetYear(dt).ToString("D4");
            var persianMonth = pc.GetMonth(dt).ToString("D2");
            var persianDay = pc.GetDayOfMonth(dt).ToString("D2");
            persianYear = persianYear.Substring(1);

            var sb=new StringBuilder();
            sb.Append(persianYear);
            sb.Append(persianMonth);
            sb.Append(persianDay);
            sb.Append("-");
            sb.Append(customerId);
            sb.Append(bookingId);


            //رقم هزار به دلیل بدون استفاده بودن و برای کاهش یک رقم از شناسه سفارش حذف می شود.
            
            //var returnValue = persianYear + persianMonth + persianDay + "-" + customerId + bookingId;
            //return returnValue;
            return sb.ToString();

            #region Examples

            //13980214-400-5
            //3980214-400-5
            //4000214-620-1
            //4001011-620-1
            //14001011-620-1
            //000504-365-5
            //000504-366-5
            //000504-367-1
            //000504-368-1
            //000504-5001-1
            //000504-5002-2
            //980214-5-3
            //9802-1001-1

            #endregion
        }

        public static string GenerateOrderPrintCode(DateTime dt, int orderId, int customerId)
        {
            var pc = new PersianCalendar();
            var persianYear = pc.GetYear(dt).ToString("D4");
            var persianMonth = pc.GetMonth(dt).ToString("D2");
            var persianDay = pc.GetDayOfMonth(dt).ToString("D2");

            //رقم هزار به دلیل بدون استفاده بودن و برای کاهش یک رقم از شناسه سفارش حذف می شود.
            persianYear = persianYear.Substring(1);

            var sb=new StringBuilder();
            sb.Append(persianYear);
            sb.Append(persianMonth);
            sb.Append(persianDay);
            sb.Append("-");
            sb.Append(orderId);
            sb.Append("-");
            sb.Append(customerId);


            return sb.ToString();
        }
    }
}
