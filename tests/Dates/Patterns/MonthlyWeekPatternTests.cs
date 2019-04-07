// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assorted.Utils.Dates.Patterns.Tests
{
    [TestFixture]
    [TestOf(typeof(MonthlyWeekPattern))]
    public class MonthlyWeekPatternTests
    {
        static IEnumerable<TestCaseData> TestData()
        {
            var startTime = TimeSpan.FromDays(0.123456789);

            yield return new TestCaseData(WeekOfMonth.First, DaysOfTheWeek.Monday, 1, new DateTime(2019, 01, 01).Add(startTime), 7)
                .Returns(new[]
                {
                    new DateTime(2019, 01, 07).Add(startTime),
                    new DateTime(2019, 02, 04).Add(startTime),
                    new DateTime(2019, 03, 04).Add(startTime),
                    new DateTime(2019, 04, 01).Add(startTime),
                    new DateTime(2019, 05, 06).Add(startTime),
                    new DateTime(2019, 06, 03).Add(startTime),
                    new DateTime(2019, 07, 01).Add(startTime),
                });

            yield return new TestCaseData(WeekOfMonth.First, DaysOfTheWeek.Monday, 2, new DateTime(2019, 01, 01).Add(startTime), 7)
                .Returns(new[]
                {
                    new DateTime(2019, 01, 07).Add(startTime),
                    new DateTime(2019, 03, 04).Add(startTime),
                    new DateTime(2019, 05, 06).Add(startTime),
                    new DateTime(2019, 07, 01).Add(startTime),
                    new DateTime(2019, 09, 02).Add(startTime),
                    new DateTime(2019, 11, 04).Add(startTime),
                    new DateTime(2020, 01, 06).Add(startTime),
                });

            yield return new TestCaseData(WeekOfMonth.Last, DaysOfTheWeek.Weekend, 1, new DateTime(2019, 01, 01).Add(startTime), 8)
                .Returns(new[]
                {
                    new DateTime(2019, 01, 27).Add(startTime),
                    new DateTime(2019, 02, 24).Add(startTime),
                    new DateTime(2019, 03, 31).Add(startTime),
                    new DateTime(2019, 04, 28).Add(startTime),
                    new DateTime(2019, 05, 26).Add(startTime),
                    new DateTime(2019, 06, 30).Add(startTime),
                    new DateTime(2019, 07, 28).Add(startTime),
                    new DateTime(2019, 08, 31).Add(startTime),
                });

            yield return new TestCaseData(WeekOfMonth.Last, DaysOfTheWeek.Weekend, 2, new DateTime(2019, 01, 01).Add(startTime), 8)
                .Returns(new[]
                {
                    new DateTime(2019, 01, 27).Add(startTime),
                    new DateTime(2019, 03, 31).Add(startTime),
                    new DateTime(2019, 05, 26).Add(startTime),
                    new DateTime(2019, 07, 28).Add(startTime),
                    new DateTime(2019, 09, 29).Add(startTime),
                    new DateTime(2019, 11, 30).Add(startTime),
                    new DateTime(2020, 01, 26).Add(startTime),
                    new DateTime(2020, 03, 29).Add(startTime),
                });
        }

        [TestCaseSource(nameof(TestData))]
        public IEnumerable<DateTime> Recurrences(WeekOfMonth weekOfMonth, DaysOfTheWeek daysOfWeek, int interval, DateTime start, int count)
        {
            var pattern = Recurrent.Monthly(weekOfMonth, daysOfWeek, interval);
            return pattern.GetRecurrencesStartingAt(start).Take(count).ToArray();
        }

        [Test]
        public void Recurrences_All()
        {
            var pattern = Recurrent.Monthly(WeekOfMonth.Second, DaysOfTheWeek.Wednesday);
            var start = DateTime.SpecifyKind(DateTime.MinValue.AddTicks(123456789), DateTimeKind.Utc);

            Assert.That(pattern.GetRecurrencesStartingAt(start).Select(date => date.Kind), Is.All.EqualTo(start.Kind));
            Assert.That(pattern.GetRecurrencesStartingAt(start).Select(date => date.TimeOfDay), Is.All.EqualTo(start.TimeOfDay));
            Assert.That(pattern.GetRecurrencesStartingAt(start).Select(date => date.DayOfWeek), Is.All.EqualTo(DayOfWeek.Wednesday));
            Assert.That(pattern.GetRecurrencesStartingAt(start).Select(date => date.DayOfWeekInstance()), Is.All.EqualTo(WeekOfMonth.Second));
        }

        [Test]
        public void Object_Equality()
        {
            var pattern1 = Recurrent.Monthly(WeekOfMonth.First, DaysOfTheWeek.Weekend, interval: 2);
            var pattern2 = Recurrent.Monthly(WeekOfMonth.First, DaysOfTheWeek.Weekend, interval: 2);

            Assert.That(pattern1, Is.EqualTo(pattern2));
        }

        [Test]
        public void Object_Inequality()
        {
            var pattern1 = Recurrent.Monthly(WeekOfMonth.First, DaysOfTheWeek.Weekend, interval: 1);
            var pattern2 = Recurrent.Monthly(WeekOfMonth.First, DaysOfTheWeek.Weekday, interval: 1);
            var pattern3 = Recurrent.Monthly(WeekOfMonth.Last, DaysOfTheWeek.Weekend, interval: 1);
            var pattern4 = Recurrent.Monthly(WeekOfMonth.Last, DaysOfTheWeek.Weekend, interval: 2);

            Assert.That(pattern1, Is.Not.EqualTo(pattern2));
            Assert.That(pattern1, Is.Not.EqualTo(pattern3));
            Assert.That(pattern1, Is.Not.EqualTo(pattern4));
            Assert.That(pattern2, Is.Not.EqualTo(pattern3));
            Assert.That(pattern2, Is.Not.EqualTo(pattern4));
            Assert.That(pattern3, Is.Not.EqualTo(pattern4));
        }

        [Test]
        public void HashCode_Equality()
        {
            var pattern1 = Recurrent.Monthly(WeekOfMonth.First, DaysOfTheWeek.Weekend, interval: 2);
            var pattern2 = Recurrent.Monthly(WeekOfMonth.First, DaysOfTheWeek.Weekend, interval: 2);

            Assert.That(pattern1.GetHashCode() == pattern2.GetHashCode());
        }

        [Test]
        public void HashCode_Inequality()
        {
            var pattern1 = Recurrent.Monthly(WeekOfMonth.First, DaysOfTheWeek.Weekend, interval: 1);
            var pattern2 = Recurrent.Monthly(WeekOfMonth.First, DaysOfTheWeek.Weekday, interval: 1);
            var pattern3 = Recurrent.Monthly(WeekOfMonth.Last, DaysOfTheWeek.Weekend, interval: 1);
            var pattern4 = Recurrent.Monthly(WeekOfMonth.Last, DaysOfTheWeek.Weekend, interval: 2);

            Assert.That(pattern1.GetHashCode() != pattern2.GetHashCode());
            Assert.That(pattern1.GetHashCode() != pattern3.GetHashCode());
            Assert.That(pattern1.GetHashCode() != pattern4.GetHashCode());
            Assert.That(pattern2.GetHashCode() != pattern3.GetHashCode());
            Assert.That(pattern2.GetHashCode() != pattern4.GetHashCode());
            Assert.That(pattern3.GetHashCode() != pattern4.GetHashCode());
        }
    }
}