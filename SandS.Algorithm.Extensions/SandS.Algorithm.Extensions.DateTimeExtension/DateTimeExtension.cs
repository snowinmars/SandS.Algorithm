using System;

namespace SandS.Algorithm.Extensions.DateTimeExtension
{
    public static class DateTimeExtension
    {
        public static bool IsFromFuture(this DateTime date)
            => !date.IsFromPast();

        public static bool IsFromPast(this DateTime date)
        {
            DateTime today = DateTime.Now;

            return date < today;
        }
    }
}