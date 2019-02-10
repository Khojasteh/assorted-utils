using System;
using System.Globalization;

namespace Assorted.Utils.Dates
{
    /// <summary>
    /// Extends the <see cref="DateTime"/> type.
    /// </summary>
    /// <threadsafety/>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Indicates whether the <see cref="DateTime"/> value is in a leap year.
        /// </summary>
        /// <param name="date">A <see cref="DateTime"/> value.</param>
        /// <returns><see langword="true"/> if the <paramref name="date"/> is in a leap year; otherwise, <see langword="false"/>.</returns>
        public static bool IsInLeapYear(this DateTime date)
        {
            return DateTime.IsLeapYear(date.Year);
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> value with a new <see cref="DateTime.Date"/> while preserving
        /// the original <see cref="DateTime.TimeOfDay"/> and <see cref="DateTime.Kind"/> values.
        /// </summary>
        /// <param name="moment">A <see cref="DateTime"/> value.</param>
        /// <param name="date">The new date.</param>
        /// <returns>The <see cref="DateTime"/> value with the new date.</returns>
        public static DateTime ReplaceDate(this DateTime moment, DateTime date)
        {
            return moment.AddDays((date.Date - moment.Date).TotalDays);
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> value with a new <see cref="DateTime.TimeOfDay"/> while preserving
        /// the original <see cref="DateTime.Date"/> and <see cref="DateTime.Kind"/> values.
        /// </summary>
        /// <param name="moment">A <see cref="DateTime"/> value.</param>
        /// <param name="time">The new time.</param>
        /// <returns>The <see cref="DateTime"/> value with the new time of day.</returns>
        public static DateTime ReplaceTime(this DateTime moment, TimeSpan time)
        {
            return moment.Date.Add(time);
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> value that represents the first moment of the millisecond.
        /// </summary>
        /// <param name="moment">A <see cref="DateTime"/> value.</param>
        /// <returns>The <see cref="DateTime"/> value of the first moment of the millisecond.</returns>
        public static DateTime StartOfMillisecond(this DateTime moment)
        {
            return moment.AddTicks(-moment.TimeOfDay.TicksResidue(TimeSpan.TicksPerMillisecond));
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> value that represents the last moment of the millisecond.
        /// </summary>
        /// <param name="moment">A <see cref="DateTime"/> value.</param>
        /// <returns>The <see cref="DateTime"/> value of the last moment of the millisecond.</returns>
        public static DateTime EndOfMillisecond(this DateTime moment)
        {
            return moment.AddTicks(TimeSpan.TicksPerMillisecond - moment.TimeOfDay.TicksResidue(TimeSpan.TicksPerMillisecond) - 1);
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> value that represents the first moment of the second.
        /// </summary>
        /// <param name="moment">A <see cref="DateTime"/> value.</param>
        /// <returns>The <see cref="DateTime"/> value of the first moment of the second.</returns>
        public static DateTime StartOfSecond(this DateTime moment)
        {
            return moment.AddTicks(-moment.TimeOfDay.TicksResidue(TimeSpan.TicksPerSecond));
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> value that represents the last moment of the second.
        /// </summary>
        /// <param name="moment">A <see cref="DateTime"/> value.</param>
        /// <returns>The <see cref="DateTime"/> value of the last moment of the second.</returns>
        public static DateTime EndOfSecond(this DateTime moment)
        {
            return moment.AddTicks(TimeSpan.TicksPerSecond - moment.TimeOfDay.TicksResidue(TimeSpan.TicksPerSecond) - 1);
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> value that represents the first moment of the minute.
        /// </summary>
        /// <param name="moment">A <see cref="DateTime"/> value.</param>
        /// <returns>The <see cref="DateTime"/> value of the first moment of the minute.</returns>
        public static DateTime StartOfMinute(this DateTime moment)
        {
            return moment.AddTicks(-moment.TimeOfDay.TicksResidue(TimeSpan.TicksPerMinute));
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> value that represents the last moment of the minute.
        /// </summary>
        /// <param name="moment">A <see cref="DateTime"/> value.</param>
        /// <returns>The <see cref="DateTime"/> value of the last moment of the minute.</returns>
        public static DateTime EndOfMinute(this DateTime moment)
        {
            return moment.AddTicks(TimeSpan.TicksPerMinute - moment.TimeOfDay.TicksResidue(TimeSpan.TicksPerMinute) - 1);
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> value that represents the first moment of the hour.
        /// </summary>
        /// <param name="moment">A <see cref="DateTime"/> value.</param>
        /// <returns>The <see cref="DateTime"/> value of the first moment of the hour.</returns>
        public static DateTime StartOfHour(this DateTime moment)
        {
            return moment.AddTicks(-moment.TimeOfDay.TicksResidue(TimeSpan.TicksPerHour));
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> value that represents the last moment of the hour.
        /// </summary>
        /// <param name="moment">A <see cref="DateTime"/> value.</param>
        /// <returns>The <see cref="DateTime"/> value of the last moment of the hour.</returns>
        public static DateTime EndOfHour(this DateTime moment)
        {
            return moment.AddTicks(TimeSpan.TicksPerHour - moment.TimeOfDay.TicksResidue(TimeSpan.TicksPerHour) - 1);
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> value that represents the first moment of the day.
        /// </summary>
        /// <param name="moment">A <see cref="DateTime"/> value.</param>
        /// <returns>The <see cref="DateTime"/> value of the first moment of the day.</returns>
        public static DateTime StartOfDay(this DateTime moment)
        {
            return moment.Date;
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> value that represents the last moment of the day.
        /// </summary>
        /// <param name="moment">A <see cref="DateTime"/> value.</param>
        /// <returns>The <see cref="DateTime"/> value of the last moment of the day.</returns>
        public static DateTime EndOfDay(this DateTime moment)
        {
            return moment.Date.AddTicks(TimeSpan.TicksPerDay - 1);
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> value that represents the first moment of the week. 
        /// </summary>
        /// <param name="date">A <see cref="DateTime"/> value.</param>
        /// <param name="firstDayOfWeek">The first day of week.</param>
        /// <returns>The <see cref="DateTime"/> value of the first day of the week.</returns>
        public static DateTime StartOfWeek(this DateTime date, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
        {
            return date.StartOfDay().AddDays(-date.DaysFromStartOfTheWeek(firstDayOfWeek));
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> value that represents the last moment of the week.
        /// </summary>
        /// <param name="date">A <see cref="DateTime"/> value.</param>
        /// <param name="firstDayOfWeek">The first day of week.</param>
        /// <returns>The <see cref="DateTime"/> value of the last day of the week.</returns>
        public static DateTime EndOfWeek(this DateTime date, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
        {
            return date.EndOfDay().AddDays(6 - date.DaysFromStartOfTheWeek(firstDayOfWeek));
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> value that represents the first moment of the month.
        /// </summary>
        /// <param name="date">A <see cref="DateTime"/> value.</param>
        /// <returns>The <see cref="DateTime"/> value of the first day of the month.</returns>
        public static DateTime StartOfMonth(this DateTime date)
        {
            return date.StartOfDay().AddDays(1 - date.Day);
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> value that represents the last moment of the month.
        /// </summary>
        /// <param name="date">A <see cref="DateTime"/> value.</param>
        /// <returns>The <see cref="DateTime"/> value of the last day of the month.</returns>
        public static DateTime EndOfMonth(this DateTime date)
        {
            return date.EndOfDay().AddDays(date.DaysInMonth() - date.Day);
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> value that represents the first moment of the year.
        /// </summary>
        /// <param name="date">A <see cref="DateTime"/> value.</param>
        /// <returns>The <see cref="DateTime"/> value of the first day of the year.</returns>
        public static DateTime StartOfYear(this DateTime date)
        {
            return date.StartOfDay().AddDays(1 - date.DayOfYear);
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> value that represents the last moment of the year.
        /// </summary>
        /// <param name="date">A <see cref="DateTime"/> value.</param>
        /// <returns>The <see cref="DateTime"/> value of the last day of the year.</returns>
        public static DateTime EndOfYear(this DateTime date)
        {
            return date.EndOfDay().AddDays(date.DaysInYear() - date.DayOfYear);
        }

        /// <summary>
        /// Returns the week number within the month.
        /// </summary>
        /// <param name="date">A <see cref="DateTime"/> value.</param>
        /// <param name="firstDayOfWeek">The first day of the week.</param>
        /// <returns>The week of the month.</returns>
        public static WeekOfMonth WeekOfMonth(this DateTime date, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
        {
            var offset = DateUtils.DaysPerWeek - date.DaysFromStartOfTheWeek(firstDayOfWeek);
            return (WeekOfMonth)((offset + DateUtils.DaysPerWeek + date.Day - 1) / DateUtils.DaysPerWeek);
        }

        /// <summary>
        /// Returns on which week of the month the day of the week appears.
        /// </summary>
        /// <param name="date">A <see cref="DateTime"/> value.</param>
        /// <returns>The week of the month.</returns>
        public static WeekOfMonth DayOfWeekInstance(this DateTime date)
        {
            return (WeekOfMonth)((DateUtils.DaysPerWeek + date.Day - 1) / DateUtils.DaysPerWeek);
        }

        /// <summary>
        /// Returns the number of days between this date and start of the week.
        /// </summary>
        /// <param name="date">A <see cref="DateTime"/> value.</param>
        /// <param name="firstDayOfWeek">The first day of the week.</param>
        /// <returns>A number between 0 and 6, where zero indicates that the date is on first day of the week.</returns>
        public static int DaysFromStartOfTheWeek(this DateTime date, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
        {
            return date.DayOfWeek.DaysFromStartOfTheWeek(firstDayOfWeek);
        }

        /// <summary>
        /// Returns the number of days in the month given by the value of this instance.
        /// </summary>
        /// <param name="date">A <see cref="DateTime"/> value.</param>
        /// <returns>The number of days in the month.</returns>
        public static int DaysInMonth(this DateTime date)
        {
            return DateTime.DaysInMonth(date.Year, date.Month);
        }

        /// <summary>
        /// Returns the number of days in the year given by the value of this instance.
        /// </summary>
        /// <param name="date">A <see cref="DateTime"/> value.</param>
        /// <returns>The number of days in the year.</returns>
        public static int DaysInYear(this DateTime date)
        {
            return date.IsInLeapYear() ? 366 : 365;
        }

        /// <summary>
        /// Returns the number of <c>ISO-8601</c> weeks in the year given by the value of this instance.
        /// </summary>
        /// <param name="date">A <see cref="DateTime"/> value.</param>
        /// <returns>The number of <c>ISO-8601</c> weeks in the year.</returns>
        public static int WeeksInYear(this DateTime date)
        {
            return DateUtils.WeeksInYear(date.Year);
        }

        /// <summary>
        /// Returns <c>ISO-8601</c> year, week of the year and day of the week.
        /// </summary>
        /// <param name="date">A <see cref="DateTime"/> value.</param>
        /// <returns>
        /// The <c>ISO-8601</c> year, week of the year and day of the week.
        /// </returns>
        public static (int Year, int Week, int DoW) ToIso8601(this DateTime date)
        {
            var dow = date.DaysFromStartOfTheWeek(DayOfWeek.Monday) + 1;

            var adjustedDate = (dow <= 3) ? date.AddDays(3) : date;

            var week = WeekCalendar.Instance.GetWeekOfYear(adjustedDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var year = adjustedDate.Year;
            if (week == 1 && adjustedDate.Month == 12)
                ++year;
            else if (week >= 52 && adjustedDate.Month == 1)
                --year;

            return (year, week, dow);
        }

        /// <summary>
        /// Returns the string representation of the date in <c>ISO-8601</c> format.
        /// </summary>
        /// <param name="date">A <see cref="DateTime"/> value.</param>
        /// <returns>The string representation of the <paramref name="date"/> in <c>ISO-8601</c> format.</returns>
        public static string FormatIso8601(this DateTime date)
        {
            var (year, week, dow) = date.ToIso8601();

            return string.Format("{0:D4}-W{1:D2}-{2:D1}", year, week, dow);
        }

        #region Helpers

        private static long TicksResidue(this TimeSpan time, long granularity) => time.Ticks % granularity;

        private static class WeekCalendar
        {
            public static readonly GregorianCalendar Instance = new GregorianCalendar(GregorianCalendarTypes.USEnglish);
        }

        #endregion
    }
}
