// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using System;

namespace Assorted.Utils.Dates
{
    using Patterns;

    /// <summary>
    /// This class provides some factory methods creating concrete instances of the <see cref="IRecurrentPattern"/> interface.
    /// </summary>
    /// <threadsafety/>
    public static class Recurrent
    {
        /// <summary>
        /// Returns a daily reoccurring pattern.
        /// </summary>
        /// <param name="interval">The interval of occurrences in number of days.</param>
        /// <returns>An instance of <see cref="DailyPattern"/> class.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="interval"/> is less than 1.</exception>
        public static DailyPattern Daily(int interval = 1)
        {
            return new DailyPattern(interval);
        }

        /// <overloads>
        /// Returns a weekly reoccurring pattern.
        /// </overloads>
        /// <summary>
        /// Returns a weekly reoccurring pattern when events occur on a specific day of the week.
        /// </summary>
        /// <param name="dayOfWeek">The day of the week when the event occurs.</param>
        /// <param name="interval">The interval of occurrences in number of weeks.</param>
        /// <param name="firstDayOfWeek">The first day of the week.</param>
        /// <returns>An instance of <see cref="WeeklyPattern"/> class.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="interval"/> is less than 1.</exception>
        public static WeeklyPattern Weekly(DayOfWeek dayOfWeek, int interval = 1, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
        {
            return new WeeklyPattern(dayOfWeek.ToDaysOfWeek(), interval, firstDayOfWeek);
        }

        /// <summary>
        /// Returns a weekly reoccurring pattern when events occur on the specified days of the week.
        /// </summary>
        /// <param name="daysOfWeek">The days of the week when the event occurs.</param>
        /// <param name="interval">The interval of occurrences in number of weeks.</param>
        /// <param name="firstDayOfWeek">The first day of the week.</param>
        /// <returns>An instance of <see cref="WeeklyPattern"/> class.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="interval"/> is less than 1.</exception>
        public static WeeklyPattern Weekly(DaysOfTheWeek daysOfWeek, int interval = 1, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
        {
            return new WeeklyPattern(daysOfWeek, interval, firstDayOfWeek);
        }

        /// <overloads>
        /// Returns a monthly reoccurring pattern.
        /// </overloads>
        /// <summary>
        /// Returns a monthly reoccurring pattern when events occur on a specific day of the month.
        /// </summary>
        /// <param name="dayOfMonth">The day of the month when the event occurs.</param>
        /// <param name="interval">The interval of occurrences in number of months.</param>
        /// <returns>An instance of <see cref="MonthlyDayPattern"/> class.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="dayOfMonth"/> is less than 1 or greater than 31. Or,
        /// <paramref name="interval"/> is less than 1.
        /// </exception>
        public static MonthlyDayPattern Monthly(int dayOfMonth, int interval = 1)
        {
            return new MonthlyDayPattern(dayOfMonth, interval);
        }

        /// <summary>
        /// Returns a monthly reoccurring pattern when events occur on one of the specified days of the week and a
        /// specific week of the month.
        /// </summary>
        /// <param name="weekOfMonth">The week of the month when the event occurs.</param>
        /// <param name="daysOfWeek">The accepted days of the week when the event can occur.</param>
        /// <param name="interval">The interval of occurrences in number of months.</param>
        /// <returns>An instance of <see cref="MonthlyWeekPattern"/> class.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="interval"/> is less than 1.</exception>
        public static MonthlyWeekPattern Monthly(WeekOfMonth weekOfMonth, DaysOfTheWeek daysOfWeek, int interval = 1)
        {
            return new MonthlyWeekPattern(weekOfMonth, daysOfWeek, interval);
        }

        /// <summary>
        /// Returns a monthly reoccurring pattern when events occur on a specific day of the week and a
        /// specific week of the month.
        /// </summary>
        /// <param name="weekOfMonth">The week of the month when the event occurs.</param>
        /// <param name="dayOfWeek">The day of the week when the event occurs.</param>
        /// <param name="interval">The interval of occurrences in number of months.</param>
        /// <returns>An instance of <see cref="MonthlyWeekPattern"/> class.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="interval"/> is less than 1.</exception>
        public static MonthlyWeekPattern Monthly(WeekOfMonth weekOfMonth, DayOfWeek dayOfWeek, int interval = 1)
        {
            return new MonthlyWeekPattern(weekOfMonth, dayOfWeek.ToDaysOfWeek(), interval);
        }

        /// <overloads>
        /// Returns a yearly reoccurring pattern.
        /// </overloads>
        /// <summary>
        /// Returns a yearly reoccurring pattern when events occur on a specific day of the month and a
        /// specific month of the year.
        /// </summary>
        /// <param name="monthOfYear">The month when the event occurs.</param>
        /// <param name="dayOfMonth">The day of the month when the event occurs.</param>
        /// <param name="interval">The interval of occurrences in number of years.</param>
        /// <returns>An instance of <see cref="YearlyMonthPattern"/> class.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="dayOfMonth"/> is less than 1 or greater than the last day of the month
        /// specified by the <paramref name="monthOfYear"/> parameter. Or,
        /// <paramref name="interval"/> is less than 1.
        /// </exception>
        public static YearlyMonthPattern Yearly(MonthOfYear monthOfYear, int dayOfMonth, int interval = 1)
        {
            return new YearlyMonthPattern((int)monthOfYear, dayOfMonth, interval);
        }

        /// <summary>
        /// Returns a yearly reoccurring pattern when events occur on a specific day of the month and a
        /// specific month of the year.
        /// </summary>
        /// <param name="monthOfYear">The month when the event occurs.</param>
        /// <param name="dayOfMonth">The day of the month when the event occurs.</param>
        /// <param name="interval">The interval of occurrences in number of years.</param>
        /// <returns>An instance of <see cref="YearlyMonthPattern"/> class.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="dayOfMonth"/> is less than 1 or greater than the last day of the month
        /// specified by the <paramref name="monthOfYear"/> parameter. Or,
        /// <paramref name="interval"/> is less than 1.
        /// </exception>
        public static YearlyMonthPattern Yearly(int monthOfYear, int dayOfMonth, int interval = 1)
        {
            return new YearlyMonthPattern(monthOfYear, dayOfMonth, interval);
        }

        /// <summary>
        /// Returns a yearly reoccurring pattern when events occur on one of the specified days of the week and a
        /// specific week of a month of the year.
        /// </summary>
        /// <param name="weekOfMonth">The week of the month when the event occurs.</param>
        /// <param name="daysOfWeek">The accepted days of the week when the event can occur.</param>
        /// <param name="monthOfYear">The month when the event occurs.</param>
        /// <param name="interval">The interval of occurrences in number of years.</param>
        /// <returns>An instance of <see cref="YearlyWeekPattern"/> class.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="interval"/> is less than 1.</exception>
        public static YearlyWeekPattern Yearly(WeekOfMonth weekOfMonth, DaysOfTheWeek daysOfWeek, MonthOfYear monthOfYear, int interval = 1)
        {
            return new YearlyWeekPattern(weekOfMonth, daysOfWeek, (int)monthOfYear, interval);
        }

        /// <summary>
        /// Returns a yearly reoccurring pattern when events occur on one of the specified days of the week and a
        /// specific week of a month of the year.
        /// </summary>
        /// <param name="weekOfMonth">The week of the month when the event occurs.</param>
        /// <param name="daysOfWeek">The accepted days of the week when the event can occur.</param>
        /// <param name="monthOfYear">The month when the event occurs.</param>
        /// <param name="interval">The interval of occurrences in number of years.</param>
        /// <returns>An instance of <see cref="YearlyWeekPattern"/> class.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="monthOfYear"/> is less than 1 or greater than 12. Or,
        /// <paramref name="interval"/> is less than 1.
        /// </exception>
        public static YearlyWeekPattern Yearly(WeekOfMonth weekOfMonth, DaysOfTheWeek daysOfWeek, int monthOfYear, int interval = 1)
        {
            return new YearlyWeekPattern(weekOfMonth, daysOfWeek, monthOfYear, interval);
        }

        /// <summary>
        /// Returns a yearly reoccurring pattern when events occur on a specific day of the week and a
        /// specific week of a month of the year.
        /// </summary>
        /// <param name="weekOfMonth">The week of the month when the event occurs.</param>
        /// <param name="dayOfWeek">The day of the week when the event occurs.</param>
        /// <param name="monthOfYear">The month when the event occurs.</param>
        /// <param name="interval">The interval of occurrences in number of years.</param>
        /// <returns>An instance of <see cref="YearlyWeekPattern"/> class.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="interval"/> is less than 1.</exception>
        public static YearlyWeekPattern Yearly(WeekOfMonth weekOfMonth, DayOfWeek dayOfWeek, MonthOfYear monthOfYear, int interval = 1)
        {
            return new YearlyWeekPattern(weekOfMonth, dayOfWeek.ToDaysOfWeek(), (int)monthOfYear, interval);
        }

        /// <summary>
        /// Returns a yearly reoccurring pattern when events occur on a specific day of the week and a
        /// specific week of a month of the year.
        /// </summary>
        /// <param name="weekOfMonth">The week of the month when the event occurs.</param>
        /// <param name="dayOfWeek">The day of the week when the event occurs.</param>
        /// <param name="monthOfYear">The month when the event occurs.</param>
        /// <param name="interval">The interval of occurrences in number of years.</param>
        /// <returns>An instance of <see cref="YearlyWeekPattern"/> class.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="monthOfYear"/> is less than 1 or greater than 12. Or,
        /// <paramref name="interval"/> is less than 1.
        /// </exception>
        public static YearlyWeekPattern Yearly(WeekOfMonth weekOfMonth, DayOfWeek dayOfWeek, int monthOfYear, int interval = 1)
        {
            return new YearlyWeekPattern(weekOfMonth, dayOfWeek.ToDaysOfWeek(), monthOfYear, interval);
        }

        /// <summary>
        /// Returns a yearly reoccurring pattern when events occur on a specific day of the year.
        /// </summary>
        /// <param name="dayOfYear">The day of the year when the event occurs.</param>
        /// <param name="interval">The interval of occurrences in number of years.</param>
        /// <returns>An instance of <see cref="YearlyDayPattern"/> class.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="dayOfYear"/> is less than 1 or greater than 366. Or,
        /// <paramref name="interval"/> is less than 1.
        /// </exception>
        public static YearlyDayPattern Yearly(int dayOfYear, int interval = 1)
        {
            return new YearlyDayPattern(dayOfYear, interval);
        }
    }
}