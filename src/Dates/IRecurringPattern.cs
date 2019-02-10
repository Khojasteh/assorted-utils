using System;
using System.Collections.Generic;

namespace Assorted.Utils.Dates
{
    /// <summary>
    /// Represents an object that generates a sequence of <see cref="DateTime"/> values based on a pattern.
    /// </summary>
    public interface IRecurrentPattern
    {
        /// <summary>
        /// Returns the sequence of recurring dates, starting at a given <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="start">The date when the recurring pattern starts.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains the recurrent dates.</returns>
        IEnumerable<DateTime> GetRecurrencesStartingAt(DateTime start);
    }
}
