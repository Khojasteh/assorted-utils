// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using System;

namespace Assorted.Utils.Dates
{
    /// <summary>
    /// Represents days of the week.
    /// </summary>
    [Flags]
    public enum DaysOfTheWeek
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>
        /// Any day
        /// </summary>
        Any = Weekday | Weekend,

        /// <summary>
        /// Monday, Tuesday, Wednesday, Thursday and Friday
        /// </summary>
        Weekday = Monday | Tuesday | Wednesday | Thursday | Friday,

        /// <summary>
        /// Saturday and Sunday
        /// </summary>
        Weekend = Saturday | Sunday,

        /// <summary>
        /// Monday
        /// </summary>
        Monday = 0x01,

        /// <summary>
        /// Tuesday
        /// </summary>
        Tuesday = 0x02,

        /// <summary>
        /// Wednesday
        /// </summary>
        Wednesday = 0x04,

        /// <summary>
        /// Thursday
        /// </summary>
        Thursday = 0x08,

        /// <summary>
        /// Friday
        /// </summary>
        Friday = 0x10,

        /// <summary>
        /// Saturday
        /// </summary>
        Saturday = 0x20,

        /// <summary>
        /// Sunday
        /// </summary>
        Sunday = 0x40
    }
}
