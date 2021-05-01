using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
namespace WebNews.Utility.MyConvert
{
    public static class Date
    {
        public static string ToSolarShort(this string date)
        {
            return DateTime
                .Parse(date)
                .ToSolarShort();
        }

        public static string ToSolarShort(this DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();

            return pc.GetYear(date) + "/" +
                   pc.GetMonth(date).ToString("00") + "/" +
                   pc.GetDayOfMonth(date).ToString("00");
        }

        public static string ToSolar(this string date)
        {
            return DateTime
                .Parse(date)
                .ToSolar();
        }

        public static string ToSolar(this DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();

            return pc.GetYear(date) + "/" +
                   pc.GetMonth(date).ToString("00") + "/" +
                   pc.GetDayOfMonth(date).ToString("00") + "  " +
                   pc.GetHour(date).ToString("00") + ":" +
                   pc.GetMinute(date).ToString("00") + ":" +
                   pc.GetSecond(date).ToString("00");
            
        }


    }
}
