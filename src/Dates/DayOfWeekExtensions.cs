using System;
using System.Collections.Generic;

namespace Assorted.Utils.Dates
{
    /// <summary>
    /// Extends the <see cref="DayOfWeek"/> and <see cref="DaysOfTheWeek"/> data types.
    /// </summary>
    /// <threadsafety/>
    public static class DayOfWeekExtensions
    {
        /// <summary>
        /// Converts the days in a <see cref="DaysOfTheWeek"/> value to a sequence of <see cref="DayOfWeek"/> values.
        /// </summary>
        /// <param name="source">The days of the week.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> that contains <see cref="DayOfWeek"/> values found in the source 
        /// <see cref="DaysOfTheWeek"/> value.
        /// </returns>
        /// <remarks>
        /// This method is implemented by using deferred execution. The immediate return value is an object that stores all 
        /// the information that is required to perform the action.
        /// </remarks>
        public static IEnumerable<DayOfWeek> AsEnumerable(this DaysOfTheWeek source)
        {
            if (DaysOfTheWeek.Monday == (source & DaysOfTheWeek.Monday))
                yield return DayOfWeek.Monday;
            if (DaysOfTheWeek.Tuesday == (source & DaysOfTheWeek.Tuesday))
                yield return DayOfWeek.Tuesday;
            if (DaysOfTheWeek.Wednesday == (source & DaysOfTheWeek.Wednesday))
                yield return DayOfWeek.Wednesday;
            if (DaysOfTheWeek.Thursday == (source & DaysOfTheWeek.Thursday))
                yield return DayOfWeek.Thursday;
            if (DaysOfTheWeek.Friday == (source & DaysOfTheWeek.Friday))
                yield return DayOfWeek.Friday;
            if (DaysOfTheWeek.Saturday == (source & DaysOfTheWeek.Saturday))
                yield return DayOfWeek.Saturday;
            if (DaysOfTheWeek.Sunday == (source & DaysOfTheWeek.Sunday))
                yield return DayOfWeek.Sunday;
        }

        /// <summary>
        /// Converts the sequence of <see cref="DayOfWeek"/> values to a <see cref="DaysOfTheWeek"/> value.
        /// </summary>
        /// <param name="source">A collection of <see cref="DayOfWeek"/> values.</param>
        /// <returns>A <see cref="DaysOfTheWeek"/> value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static DaysOfTheWeek AsFlags(this IEnumerable<DayOfWeek> source)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));

            var daysOfWeek = DaysOfTheWeek.None;
            foreach (var dayOfWeek in source)
                daysOfWeek |= dayOfWeek.ToDaysOfWeek();
                
            return daysOfWeek;
        }

        /// <summary>
        /// Converts a <see cref="DayOfWeek"/> value to a <see cref="DaysOfTheWeek"/> value.
        /// </summary>
        /// <param name="source">The day of the week.</param>
        /// <returns>A <see cref="DaysOfTheWeek"/> value.</returns>
        public static DaysOfTheWeek ToDaysOfWeek(this DayOfWeek source)
        {
            return (DaysOfTheWeek)(1 << source.DaysFromStartOfTheWeek());
        }

        /// <summary>
        /// Returns the number of days between this day of the week and start of the week.
        /// </summary>
        /// <param name="dayOfWeek">The day of the week.</param>
        /// <param name="firstDayOfWeek">The first day of the week.</param>
        /// <returns>A number between 0 and 6, where zero indicates that the day of the week is the first day of the week.</returns>
        public static int DaysFromStartOfTheWeek(this DayOfWeek dayOfWeek, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
        {
            var offset = dayOfWeek - firstDayOfWeek;
            return (offset < 0) ? offset + 7 : offset;
        }
    }
}
