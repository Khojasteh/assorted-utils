// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using System;
using System.Text.RegularExpressions;

namespace Assorted.Utils.Dates
{
    /// <summary>
    /// Provides some helper methods for working with <see cref="DateTime"/> values.
    /// </summary>
    /// <threadsafety/>
    public static class DateUtils
    {
        /// <summary>
        /// The number of days in a week.
        /// </summary>
        public const int DaysPerWeek = 7;

        /// <summary>
        /// Returns the day of the week for the number of days after start of the week.
        /// </summary>
        /// <param name="days">The number of days after start of the week.</param>
        /// <param name="firstDayOfWeek">The first day of the week.</param>
        /// <returns>The day of the week.</returns>
        public static DayOfWeek DaysFromStartOfTheWeekToDayOfWeek(int days, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
        {
            var dow = (days + (int)firstDayOfWeek) % DaysPerWeek;
            return (DayOfWeek)((dow < 0) ? dow + DaysPerWeek : dow);
        }

        /// <summary>
        /// Returns the date for a specific occurrence of a given day of the week in a specific month of the year.
        /// </summary>
        /// <param name="weekOfMonth">The week of the month.</param>
        /// <param name="dayOfWeek">The day of the week.</param>
        /// <param name="monthOfYear">The month of the year.</param>
        /// <param name="year">The year.</param>
        /// <returns>A <see cref="DateTime"/> value.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="year"/> is less than 1 or greater than 9999.</exception>
        public static DateTime DateFor(WeekOfMonth weekOfMonth, DayOfWeek dayOfWeek, MonthOfYear monthOfYear, int year)
        {
            return DateFor(weekOfMonth, dayOfWeek, (int)monthOfYear, year);
        }

        /// <summary>
        /// Returns the date for a specific occurrence of a given day of the week in a specified month of a the year.
        /// </summary>
        /// <param name="weekOfMonth">The week instance of the month.</param>
        /// <param name="dayOfWeek">The day of the week.</param>
        /// <param name="month">The month of the year.</param>
        /// <param name="year">The year.</param>
        /// <returns>A <see cref="DateTime"/> value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="year"/> is less than 1 or greater than 9999. Or,
        /// <paramref name="month"/> is less than 1 or greater than 12.
        /// </exception>
        public static DateTime DateFor(WeekOfMonth weekOfMonth, DayOfWeek dayOfWeek, int month, int year)
        {
            Contract.Requires<ArgumentOutOfRangeException>(year >= 1 && year <= 9999, nameof(year));
            Contract.Requires<ArgumentOutOfRangeException>(month >= 1 && month <= 12, nameof(month));

            var firstOfMonth = new DateTime(year, month, 1);
            var daysInWholeWeeks = ((int)weekOfMonth - 1) * DaysPerWeek;

            var daysFromStartOfMonth = dayOfWeek.DaysFromStartOfTheWeek() - firstOfMonth.DayOfWeek.DaysFromStartOfTheWeek();
            if (daysFromStartOfMonth < 0)
                daysFromStartOfMonth += DaysPerWeek;
            daysFromStartOfMonth += daysInWholeWeeks;
            if (weekOfMonth == WeekOfMonth.Last && daysFromStartOfMonth >= DateTime.DaysInMonth(year, month))
                daysFromStartOfMonth -= DaysPerWeek;

            return firstOfMonth.AddDays(daysFromStartOfMonth);
        }

        /// <summary>
        /// Converts a specified <c>ISO-8601</c> year, week of the year and day of the week to its <see cref="DateTime"/>
        /// equivalent value.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="week">The week of the year.</param>
        /// <param name="dayOfWeek">The day of the week.</param>
        /// <returns>
        /// A <see cref="DateTime"/> value that is equivalent to the specified <c>ISO-8601</c> year,
        /// week of the year and day of the week.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="year"/> is less than 1 or greater than 9999. Or,
        /// <paramref name="week"/> is less than 1 or greater than 53.
        /// </exception>
        public static DateTime DateForIso8601(int year, int week, DayOfWeek dayOfWeek)
        {
            Contract.Requires<ArgumentOutOfRangeException>(year >= 1 && year <= 9999, nameof(year));
            Contract.Requires<ArgumentOutOfRangeException>(week >= 1 && week <= 53, nameof(week));

            var firstDayOfYear = new DateTime(year, 1, 1);
            var firstDayOfYearFromStartOfWeek = firstDayOfYear.DaysFromStartOfTheWeek(DayOfWeek.Monday);
            var daysInWholeWeeks = (week - 1) * DaysPerWeek;

            var daysFromStartOfYear = dayOfWeek.DaysFromStartOfTheWeek() - firstDayOfYearFromStartOfWeek + daysInWholeWeeks;
            if (firstDayOfYearFromStartOfWeek > 3)
                daysFromStartOfYear += DaysPerWeek;

            return firstDayOfYear.AddDays(daysFromStartOfYear);
        }

        /// <summary>
        /// Converts the string representation of a date in <c>ISO-8601</c> format to its <see cref="DateTime"/>
        /// equivalent value.
        /// </summary>
        /// <param name="s">A <see cref="string"/> that contains a date in <c>ISO-8601</c> format.</param>
        /// <returns>A <see cref="DateTime"/> value that is equivalent to the date contained in <paramref name="s"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">
        /// <paramref name="s"/> does not contain a valid string representation of a date in <c>ISO-8601</c> format.
        /// </exception>
        public static DateTime ParseIso8601(string s)
        {
            Contract.Requires<ArgumentNullException>(s != null, nameof(s));

            var m = Iso8601.Pattern.Match(s);
            if (!m.Success)
                throw new FormatException();

            var year = int.Parse(m.Groups[1].Value);
            var week = int.Parse(m.Groups[2].Value);
            var dow = int.Parse(m.Groups[3].Value);

            if (year == 0 || week == 0 || week > 53)
                throw new FormatException();

            return DateForIso8601(year, week, DaysFromStartOfTheWeekToDayOfWeek(dow - 1));
        }

        /// <summary>
        /// Returns the number of <c>ISO-8601</c> weeks in a given year.
        /// </summary>
        /// <param name="year">The year of interest.</param>
        /// <returns>The number of ISO-8601 weeks in the specified <paramref name="year"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="year"/> is less than 1 or greater than 9999.</exception>
        public static int WeeksInYear(int year)
        {
            Contract.Requires<ArgumentOutOfRangeException>(year >= 1 && year <= 9999, nameof(year));

            var weeks = 52;

            var dow = new DateTime(year, 1, 1).DayOfWeek;
            if (dow == DayOfWeek.Thursday || (dow == DayOfWeek.Wednesday && DateTime.IsLeapYear(year)))
                weeks++;

            return weeks;
        }

        #region Helper

        private static class Iso8601
        {
            public readonly static Regex Pattern = new Regex(@"(\d{4})-[wW](\d{2})-([1-7])", RegexOptions.Compiled);
        }

        #endregion
    }
}
