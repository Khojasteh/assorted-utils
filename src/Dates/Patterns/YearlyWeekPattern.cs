using System;
using System.Collections.Generic;
using System.Linq;

namespace Assorted.Utils.Dates.Patterns
{
    /// <summary>
    /// Generates a sequence of <see cref="DateTime"/> values based on a monthly reoccurring pattern
    /// when events occur on a specific day of the week and a specific week of a month of the year.
    /// </summary>
    /// <remarks>
    /// If <see cref="YearlyWeekPattern.DaysOfWeek"/> property indicates that multiple days of the 
    /// week are acceptable as the recurring day, the event occurs only on the earliest day. However, 
    /// if <see cref="YearlyWeekPattern.WeekOfMonth"/> is <see cref="WeekOfMonth.Last"/>, the event 
    /// occurs on the latest day.
    /// </remarks>
    /// <threadsafety static="true" instance="true"/>
    public class YearlyWeekPattern: IRecurrentPattern, IEquatable<YearlyWeekPattern>
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
        /// Gets the week of the month when the event occurs.
        /// </summary>
        public WeekOfMonth WeekOfMonth { get; }

        /// <summary>
        /// Gets the accepted days of the week when the event can occur.
        /// </summary>
        public DaysOfTheWeek DaysOfWeek { get; }

        /// <summary>
        /// Initializes an instance of <see cref="YearlyWeekPattern"/> class.
        /// </summary>
        /// <param name="weekOfMonth">The week of the month when the event occurs.</param>
        /// <param name="daysOfWeek">The accepted days of the week when the event can occurs.</param>
        /// <param name="monthOfYear">The month when the event occurs.</param>
        /// <param name="interval">The interval of occurrences in number of years.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="monthOfYear"/> is less than 1 or greater than 12. Or,
        /// <paramref name="interval"/> is less than 1.
        /// </exception>
        public YearlyWeekPattern(WeekOfMonth weekOfMonth, DaysOfTheWeek daysOfWeek, int monthOfYear, int interval = 1)
        {
            Contract.Requires<ArgumentOutOfRangeException>(monthOfYear >= 1 && monthOfYear <= 12, nameof(monthOfYear));
            Contract.Requires<ArgumentOutOfRangeException>(interval >= 1, nameof(interval));

            MonthOfYear = monthOfYear;
            WeekOfMonth = weekOfMonth;
            DaysOfWeek = daysOfWeek & DaysOfTheWeek.Any;
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
            if (DaysOfWeek == DaysOfTheWeek.None)
                yield break;

            var year = start.Year;

            if (start.Month <= MonthOfYear)
            {
                var firstOccurrence = Occurence();
                if (firstOccurrence >= start)
                    yield return firstOccurrence;
            }

            for (year += Interval; year <= DateTime.MaxValue.Year; year += Interval)
                yield return Occurence();

            DateTime Occurence()
            {
                var dates = DaysOfWeek.AsEnumerable().Select(dayOfWeek => DateUtils.DateFor(WeekOfMonth, dayOfWeek, MonthOfYear, year));
                return start.ReplaceDate((WeekOfMonth == WeekOfMonth.Last) ? dates.Max() : dates.Min());
            }
        }

        /// <summary>
        /// Indicates whether the current instance is equal to another object of type <see cref="YearlyWeekPattern"/>.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns><see langword="true"/> if the current instance is equal to the other instance; otherwise, <see langword="false"/>.</returns>
        public bool Equals(YearlyWeekPattern other)
        {
            return (other != null) 
                && (other.MonthOfYear == MonthOfYear)
                && (other.WeekOfMonth == WeekOfMonth) 
                && (other.DaysOfWeek == DaysOfWeek) 
                && (other.Interval == Interval);
        }

        /// <summary>
        /// Determines whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare to this instance.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="obj"/> is type of <see cref="YearlyWeekPattern"/> and equals to this instance; 
        /// otherwise, <see langword="false"/>. If <paramref name="obj"/> is <see langword="null"/>, the method returns <see langword="false"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return (obj is YearlyWeekPattern other) && Equals(other);
        }
    
        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return (Interval << 15) | (MonthOfYear << 10) | ((int)WeekOfMonth << 7) | (int)DaysOfWeek;
        }
    }
}
