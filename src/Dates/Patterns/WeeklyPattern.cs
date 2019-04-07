// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Assorted.Utils.Dates.Patterns
{
    /// <summary>
    /// Generates a sequence of <see cref="DateTime"/> values based on a weekly reoccurring pattern
    /// when events occur on some specific days of the week.
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public class WeeklyPattern: IRecurrentPattern, IEquatable<WeeklyPattern>
    {
        /// <summary>
        /// Gets the interval of occurrences in number of weeks.
        /// </summary>
        public int Interval { get; }

        /// <summary>
        /// Gets the days of the week when the event occurs.
        /// </summary>
        public DaysOfTheWeek DaysOfWeek { get; }

        /// <summary>
        /// Gets the first day of the week.
        /// </summary>
        public DayOfWeek FirstDayOfWeek { get; }

        /// <summary>
        /// Initializes an instance of <see cref="WeeklyPattern"/> class.
        /// </summary>
        /// <param name="daysOfWeek">The days of the week when the event occurs.</param>
        /// <param name="interval">The interval of occurrences in number of weeks.</param>
        /// <param name="firstDayOfWeek">The first day of the week.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="interval"/> is less than 1.</exception>
        public WeeklyPattern(DaysOfTheWeek daysOfWeek, int interval = 1, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
        {
            Contract.Requires<ArgumentOutOfRangeException>(interval >= 1, nameof(interval));

            DaysOfWeek = daysOfWeek & DaysOfTheWeek.Any;
            Interval = interval;
            FirstDayOfWeek = firstDayOfWeek;
        }

        /// <summary>
        /// Returns the list of days specified by the <see cref="DaysOfWeek"/>, relative to a given date.
        /// </summary>
        /// <param name="date">The date on which the relative days must be calculated.</param>
        /// <returns>The list of days relative to the specified <paramref name="date"/>.</returns>
        protected List<int> GetRelativeDaysOfWeekTo(DateTime date)
        {
            var baseOffset = date.DaysFromStartOfTheWeek(FirstDayOfWeek);

            var offsets = new List<int>(DateUtils.DaysPerWeek);
            foreach (var day in DaysOfWeek.AsEnumerable())
                offsets.Add(day.DaysFromStartOfTheWeek(FirstDayOfWeek) - baseOffset);

            offsets.Sort();
            return offsets;
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

            var lastOffset = (DateTime.MaxValue - start).Days;
            var relativeDays = GetRelativeDaysOfWeekTo(start);

            var daysOfInterest = relativeDays.SkipWhile(offset => offset < 0);
            for (var week = 0; ; week += Interval)
            {
                foreach (var dayOfWeek in daysOfInterest)
                {
                    var offset = (week * DateUtils.DaysPerWeek) + dayOfWeek;
                    if (offset > lastOffset)
                        yield break;

                    yield return start.AddDays(offset);
                }
                daysOfInterest = relativeDays;
            }
        }

        /// <summary>
        /// Indicates whether the current instance is equal to another object of type <see cref="WeeklyPattern"/>.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns><see langword="true"/> if the current instance is equal to the other instance; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WeeklyPattern other)
        {
            return (other != null)
                && (other.DaysOfWeek == DaysOfWeek)
                && (other.Interval == Interval)
                && (other.FirstDayOfWeek == FirstDayOfWeek);
        }

        /// <summary>
        /// Determines whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare to this instance.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="obj"/> is type of <see cref="WeeklyPattern"/> and equals to this instance;
        /// otherwise, <see langword="false"/>. If <paramref name="obj"/> is <see langword="null"/>, the method returns <see langword="false"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return (obj is WeeklyPattern other) && Equals(other);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return (Interval << 11) | ((int)DaysOfWeek << 3) | (int)FirstDayOfWeek;
        }
    }
}
