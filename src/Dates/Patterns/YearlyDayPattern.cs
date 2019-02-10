using System;
using System.Collections.Generic;

namespace Assorted.Utils.Dates.Patterns
{
    /// <summary>
    /// Generates a sequence of <see cref="DateTime"/> values based on a yearly reoccurring pattern
    /// when events occur on a specific day of the year.
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public class YearlyDayPattern: IRecurrentPattern, IEquatable<YearlyDayPattern>
    {
        /// <summary>
        /// Gets the interval of occurrences in number of years.
        /// </summary>
        public int Interval { get; }

        /// <summary>
        /// Gets the day of the year when the event occurs.
        /// </summary>
        public int DayOfYear { get; }

        /// <summary>
        /// Initializes an instance of <see cref="YearlyDayPattern"/> class.
        /// </summary>
        /// <param name="dayOfYear">The day of the year when the event occurs.</param>
        /// <param name="interval">The interval of occurrences in number of years.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="dayOfYear"/> is less than 1 or greater than 366. Or,
        /// <paramref name="interval"/> is less than 1.
        /// </exception>
        public YearlyDayPattern(int dayOfYear, int interval = 1)
        {
            Contract.Requires<ArgumentOutOfRangeException>(dayOfYear >= 1 && dayOfYear <= 366, nameof(dayOfYear));
            Contract.Requires<ArgumentOutOfRangeException>(interval >= 1, nameof(interval));

            DayOfYear = dayOfYear;
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
            if (start.DayOfYear > DayOfYear)
                year += Interval;

            for (; year <= DateTime.MaxValue.Year; year += Interval)
            {
                if (DayOfYear < 366 || DateTime.IsLeapYear(year))
                    yield return start.ReplaceDate(new DateTime(year, 1, 1).AddDays(DayOfYear - 1));
            }
        }

        /// <summary>
        /// Indicates whether the current instance is equal to another object of type <see cref="YearlyDayPattern"/>.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns><see langword="true"/> if the current instance is equal to the other instance; otherwise, <see langword="false"/>.</returns>
        public bool Equals(YearlyDayPattern other)
        {
            return (other != null) 
                && (other.DayOfYear == DayOfYear) 
                && (other.Interval == Interval);
        }

        /// <summary>
        /// Determines whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare to this instance.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="obj"/> is type of <see cref="YearlyDayPattern"/> and equals to this instance; 
        /// otherwise, <see langword="false"/>. If <paramref name="obj"/> is <see langword="null"/>, the method returns <see langword="false"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return (obj is YearlyDayPattern other) && Equals(other);
        }
    
        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return (Interval << 9) | DayOfYear;
        }
    }
}
