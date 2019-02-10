using System;
using System.Collections.Generic;
using System.Linq;

namespace Assorted.Utils.Dates.Patterns
{
    /// <summary>
    /// Generates a sequence of <see cref="DateTime"/> values based on a monthly reoccurring pattern
    /// when events occur on a specific day of the week and a specific week of the month.
    /// </summary>
    /// <remarks>
    /// If <see cref="MonthlyWeekPattern.DaysOfWeek"/> property indicates that multiple days of the 
    /// week are acceptable as the recurring day, the event occurs only on the earliest day. However, 
    /// if <see cref="MonthlyWeekPattern.WeekOfMonth"/> is <see cref="WeekOfMonth.Last"/>, the event 
    /// occurs on the latest day.
    /// </remarks>
    /// <threadsafety static="true" instance="true"/>
    public class MonthlyWeekPattern: IRecurrentPattern, IEquatable<MonthlyWeekPattern>
    {
        /// <summary>
        /// Gets the interval of occurrences in number of months.
        /// </summary>
        public int Interval { get; }

        /// <summary>
        /// Gets the week of the month when the event occurs.
        /// </summary>
        public WeekOfMonth WeekOfMonth { get; }

        /// <summary>
        /// Gets the accepted days of the week when the event can occur.
        /// </summary>
        public DaysOfTheWeek DaysOfWeek { get; }

        /// <summary>
        /// Initializes an instance of <see cref="MonthlyWeekPattern"/> class.
        /// </summary>
        /// <param name="weekOfMonth">The week of the month when the event occurs.</param>
        /// <param name="daysOfWeek">The accepted days of the week when the event can occur.</param>
        /// <param name="interval">The interval of occurrences in number of months.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="interval"/> is less than 1.</exception>
        public MonthlyWeekPattern(WeekOfMonth weekOfMonth, DaysOfTheWeek daysOfWeek, int interval = 1) 
        {
            Contract.Requires<ArgumentOutOfRangeException>(interval >= 1, nameof(interval));

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
            var month = start.Month;

            var firstOccurrence = Occurence();
            if (firstOccurrence >= start)
                yield return firstOccurrence;

            for (;;)
            {
                month += Interval;
                if (month > 12)
                {
                    year += (month - 1) / 12;
                    month = (month - 1) % 12 + 1;
                    if (year > DateTime.MaxValue.Year)
                        yield break;
                }

                yield return Occurence();
            }

            DateTime Occurence()
            {
                var dates = DaysOfWeek.AsEnumerable().Select(dayOfWeek => DateUtils.DateFor(WeekOfMonth, dayOfWeek, month, year));
                return start.ReplaceDate((WeekOfMonth == WeekOfMonth.Last) ? dates.Max() : dates.Min());
            }
        }

        /// <summary>
        /// Indicates whether the current instance is equal to another object of type <see cref="MonthlyWeekPattern"/>.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns><see langword="true"/> if the current instance is equal to the other instance; otherwise, <see langword="false"/>.</returns>
        public bool Equals(MonthlyWeekPattern other)
        {
            return (other != null) 
                && (other.WeekOfMonth == WeekOfMonth) 
                && (other.DaysOfWeek == DaysOfWeek) 
                && (other.Interval == Interval);
        }

        /// <summary>
        /// Determines whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare to this instance.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="obj"/> is type of <see cref="MonthlyWeekPattern"/> and equals to this instance; 
        /// otherwise, <see langword="false"/>. If <paramref name="obj"/> is <see langword="null"/>, the method returns <see langword="false"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return (obj is MonthlyWeekPattern other) && Equals(other);
        }
    
        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return (Interval << 10) | ((int)WeekOfMonth << 7) | (int)DaysOfWeek;
        }
    }
}
