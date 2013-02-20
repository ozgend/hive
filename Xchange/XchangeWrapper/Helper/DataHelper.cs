using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Denolk.XchangeWrapper.Helper
{
    internal class DataHelper
    {
        public const string DateStringShort = "MM-dd-yyyy";
        public const string DateStringLong = "MM-dd-yyyy HH:mm";
        public const string DateStringFull = "dddd - dd MMM yyyy HH:mm ";
        public const string DateStringISO = "yyyy-MM-dd HH:mm";

        public static string FormatDate(DateTime date, string format)
        {
            return date.ToString(format);
        }

        public static string FormatDateShort(DateTime date)
        {
            return FormatDate(date, DateStringShort);
        }

        public static string FormatDateLong(DateTime date)
        {
            return FormatDate(date, DateStringLong);
        }
        public static string FormatDateFull(DateTime date)
        {
            return FormatDate(date, DateStringFull);
        }

        public static string FormatDateISO(DateTime date)
        {
            return FormatDate(date, DateStringISO);
        }

        public static DateTime StringToDate(string date, string format)
        {
            return DateTime.ParseExact(date, format, CultureInfo.InvariantCulture);
        }

    }
}
