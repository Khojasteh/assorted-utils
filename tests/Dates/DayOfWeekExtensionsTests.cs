// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Assorted.Utils.Dates.Tests
{
    [TestFixture]
    [TestOf(typeof(DayOfWeekExtensions))]
    public class DayOfWeekExtensionsTests
    {
        [TestCase(DaysOfTheWeek.None, ExpectedResult = new DayOfWeek[] { })]
        [TestCase(DaysOfTheWeek.Any, ExpectedResult = new[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday })]
        [TestCase(DaysOfTheWeek.Weekday, ExpectedResult = new[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday })]
        [TestCase(DaysOfTheWeek.Weekend, ExpectedResult = new[] { DayOfWeek.Saturday, DayOfWeek.Sunday })]
        [TestCase(DaysOfTheWeek.Monday | DaysOfTheWeek.Friday, ExpectedResult = new[] { DayOfWeek.Monday, DayOfWeek.Friday })]
        [TestCase(DaysOfTheWeek.Wednesday, ExpectedResult = new[] { DayOfWeek.Wednesday })]
        public IEnumerable<DayOfWeek> DaysOfWeek_As_Sequence_Of_DayOfWeek(DaysOfTheWeek daysOfWeek)
        {
            return daysOfWeek.AsEnumerable();
        }

        [TestCase(new DayOfWeek[] { }, ExpectedResult = DaysOfTheWeek.None)]
        [TestCase(new[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday }, ExpectedResult = DaysOfTheWeek.Any)]
        [TestCase(new[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday }, ExpectedResult = DaysOfTheWeek.Weekday)]
        [TestCase(new[] { DayOfWeek.Saturday, DayOfWeek.Sunday }, ExpectedResult = DaysOfTheWeek.Weekend)]
        [TestCase(new[] { DayOfWeek.Monday, DayOfWeek.Friday }, ExpectedResult = DaysOfTheWeek.Monday | DaysOfTheWeek.Friday)]
        [TestCase(new[] { DayOfWeek.Wednesday }, ExpectedResult = DaysOfTheWeek.Wednesday)]
        public DaysOfTheWeek Sequence_Of_DayOfWeek_As_DaysOfWeek(IEnumerable<DayOfWeek> daysOfWeek)
        {
            return daysOfWeek.AsFlags();
        }

        [TestCase(DayOfWeek.Monday, ExpectedResult = DaysOfTheWeek.Monday)]
        [TestCase(DayOfWeek.Tuesday, ExpectedResult = DaysOfTheWeek.Tuesday)]
        [TestCase(DayOfWeek.Wednesday, ExpectedResult = DaysOfTheWeek.Wednesday)]
        [TestCase(DayOfWeek.Thursday, ExpectedResult = DaysOfTheWeek.Thursday)]
        [TestCase(DayOfWeek.Friday, ExpectedResult = DaysOfTheWeek.Friday)]
        [TestCase(DayOfWeek.Saturday, ExpectedResult = DaysOfTheWeek.Saturday)]
        [TestCase(DayOfWeek.Sunday, ExpectedResult = DaysOfTheWeek.Sunday)]
        public static DaysOfTheWeek DayOfWeek_To_DaysOfWeek(DayOfWeek dayOfWeek)
        {
            return dayOfWeek.ToDaysOfWeek();
        }

        [TestCase(DayOfWeek.Monday, DayOfWeek.Monday, ExpectedResult = 0)]
        [TestCase(DayOfWeek.Monday, DayOfWeek.Friday, ExpectedResult = 4)]
        [TestCase(DayOfWeek.Monday, DayOfWeek.Sunday, ExpectedResult = 6)]
        [TestCase(DayOfWeek.Sunday, DayOfWeek.Sunday, ExpectedResult = 0)]
        [TestCase(DayOfWeek.Sunday, DayOfWeek.Monday, ExpectedResult = 1)]
        [TestCase(DayOfWeek.Sunday, DayOfWeek.Saturday, ExpectedResult = 6)]
        [TestCase(DayOfWeek.Saturday, DayOfWeek.Saturday, ExpectedResult = 0)]
        [TestCase(DayOfWeek.Saturday, DayOfWeek.Tuesday, ExpectedResult = 3)]
        [TestCase(DayOfWeek.Saturday, DayOfWeek.Friday, ExpectedResult = 6)]
        public int DaysFromStartOfTheWeek(DayOfWeek firstDayOfWeek, DayOfWeek dayOfWeek)
        {
            return dayOfWeek.DaysFromStartOfTheWeek(firstDayOfWeek);
        }
   }
}