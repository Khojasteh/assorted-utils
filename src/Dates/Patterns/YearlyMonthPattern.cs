// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using System;
using System.Collections.Generic;

namespace Assorted.Utils.Dates.Patterns
{
    /// <summary>
    /// Generates a sequence of <see cref="DateTime"/> values based on a monthly reoccurring pattern
    /// when events occur on a specific day of a specific month of the year.
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public class YearlyMonthPattern: IRecurrentPattern, IEquatable<YearlyMonthPattern>
    {
        /// <summary>
        /// Gets the interval of occurrences in number of years.
        /// </summary>
        public int Interval { get; }

        /// <summary>
        /// Gets the month when the event occurs.
        /// </summary>
        public int MonthOfYear { get; }

        /// <summary>
        /// Gets the day of the month when the event occurs.
        /// </summary>
        public int DayOfMonth { get; }

        /// <summary>
        /// Initializes an instance of <see cref="YearlyMonthPattern"/> class.
        /// </summary>
        /// <param name="monthOfYear">The month when the event occurs.</param>
        /// <param name="dayOfMonth">The day of the month when the event occurs.</param>
        /// <param name="interval">The interval of occurrences in number of years.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="monthOfYear"/> is less than 1 or greater than 12. Or,
        /// <paramref name="dayOfMonth"/> is less than 1 or greater than the last day of the month
        /// specified by the <paramref name="monthOfYear"/> parameter. Or,
        /// <paramref name="interval"/> is less than 1.
        /// </exception>
        public YearlyMonthPattern(int monthOfYear, int dayOfMonth, int interval = 1)
        {
            Contract.Requires<ArgumentOutOfRangeException>(monthOfYear >= 1 && monthOfYear <= 12, nameof(monthOfYear));
            Contract.Requires<ArgumentOutOfRangeException>(dayOfMonth >= 1 && dayOfMonth <= DateTime.DaysInMonth(2000, monthOfYear), nameof(dayOfMonth));
            Contract.Requires<ArgumentOutOfRangeException>(interval >= 1, nameof(interval));

            MonthOfYear = monthOfYear;
            DayOfMonth = dayOfMonth;
            Interval = interval;
        }

        /// <summary>
        /// Returns the sequence of recurring dates, starting at a given <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="start">The date when the recurring pattern starts.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> that contains the recurrent dates.
        /// The <see cref="DateTime.TimeOfDay"/> and <see cref="DateTime.Kind"/> of the <paramref name="start"/> date
        /// is preserved in the returned dates.
        /// </returns>
        /// <remarks>
        /// This method is implemented by using deferred execution. The immediate return value is an object that stores all
        /// the information that is required to perform the action.
        /// </remarks>
        public IEnumerable<DateTime> GetRecurrencesStartingAt(DateTime start)
        {
            var year = start.Year;
            if (start.Month > MonthOfYear || (start.Month == MonthOfYear && start.Day > DayOfMonth))
                year += Interval;

            for (; year <= DateTime.MaxValue.Year; year += Interval)
            {
                if (DayOfMonth <= DateTime.DaysInMonth(year, MonthOfYear))
                    yield return start.ReplaceDate(new DateTime(year, MonthOfYear, DayOfMonth));
            }
        }

        /// <summary>
        /// Indicates whether the current instance is equal to another object of type <see cref="YearlyMonthPattern"/>.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns><see langword="true"/> if the current instance is equal to the other instance; otherwise, <see langword="false"/>.</returns>
        public bool Equals(YearlyMonthPattern other)
        {
            return (other != null)
                && (other.MonthOfYear == MonthOfYear)
                && (other.DayOfMonth == DayOfMonth)
                && (other.Interval == Interval);
        }

        /// <summary>
        /// Determines whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare to this instance.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="obj"/> is type of <see cref="YearlyMonthPattern"/> and equals to this instance;
        /// otherwise, <see langword="false"/>. If <paramref name="obj"/> is <see langword="null"/>, the method returns <see langword="false"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return (obj is YearlyMonthPattern other) && Equals(other);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return (Interval << 9) | (MonthOfYear << 5) | DayOfMonth;
        }
    }
}
