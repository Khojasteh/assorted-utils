using System;
using System.Collections.Generic;

namespace Assorted.Utils.Dates.Patterns
{
    /// <summary>
    /// Generates a sequence of <see cref="DateTime"/> values based on a daily reoccurring pattern.
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public class DailyPattern: IRecurrentPattern, IEquatable<DailyPattern>
    {
        /// <summary>
        /// Gets the interval of occurrences in number of days.
        /// </summary>
        public int Interval { get; }

        /// <summary>
        /// Initializes an instance of <see cref="DailyPattern"/> class.
        /// </summary>
        /// <param name="interval">The interval of occurrences in number of days.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="interval"/> is less than 1.</exception>
        public DailyPattern(int interval = 1) 
        {
            Contract.Requires<ArgumentOutOfRangeException>(interval >= 1, nameof(interval));

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
            var lastOffset = (DateTime.MaxValue - start).Days;

            for (var offset = 0; offset <= lastOffset; offset += Interval)
                yield return start.AddDays(offset);
        }

        /// <summary>
        /// Indicates whether the current instance is equal to another object of type <see cref="DailyPattern"/>.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns><see langword="true"/> if the current instance is equal to the other instance; otherwise, <see langword="false"/>.</returns>
        public bool Equals(DailyPattern other)
        {
            return (other != null) && (other.Interval == Interval);
        }

        /// <summary>
        /// Determines whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare to this instance.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="obj"/> is type of <see cref="DailyPattern"/> and equals to this instance; 
        /// otherwise, <see langword="false"/>. If <paramref name="obj"/> is <see langword="null"/>, the method returns <see langword="false"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return (obj is DailyPattern other) && Equals(other);
        }
    
        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return Interval;
        }
    }
}
