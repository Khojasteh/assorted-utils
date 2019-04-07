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
    [TestOf(typeof(WeeklyPattern))]
    public class WeeklyPatternTests
    {
        static IEnumerable<TestCaseData> TestData()
        {
            var startTime = TimeSpan.FromDays(0.123456789);

            yield return new TestCaseData(DaysOfTheWeek.None, 1, DayOfWeek.Monday, new DateTime(2018, 12, 02).Add(startTime), 7)
                .Returns(new DateTime[] { });

            yield return new TestCaseData(DaysOfTheWeek.Monday, 1, DayOfWeek.Monday, new DateTime(2018, 12, 02).Add(startTime), 7)
                .Returns(new[]
                {
                    new DateTime(2018, 12, 03).Add(startTime),
                    new DateTime(2018, 12, 10).Add(startTime),
                    new DateTime(2018, 12, 17).Add(startTime),
                    new DateTime(2018, 12, 24).Add(startTime),
                    new DateTime(2018, 12, 31).Add(startTime),
                    new DateTime(2019, 01, 07).Add(startTime),
                    new DateTime(2019, 01, 14).Add(startTime),
                });

            yield return new TestCaseData(DaysOfTheWeek.Monday, 2, DayOfWeek.Monday, new DateTime(2018, 12, 02).Add(startTime), 7)
                .Returns(new[]
                {
                    new DateTime(2018, 12, 10).Add(startTime),
                    new DateTime(2018, 12, 24).Add(startTime),
                    new DateTime(2019, 01, 07).Add(startTime),
                    new DateTime(2019, 01, 21).Add(startTime),
                    new DateTime(2019, 02, 04).Add(startTime),
                    new DateTime(2019, 02, 18).Add(startTime),
                    new DateTime(2019, 03, 04).Add(startTime),
                });

            yield return new TestCaseData(DaysOfTheWeek.Monday, 2, DayOfWeek.Sunday, new DateTime(2018, 12, 02).Add(startTime), 7)
                .Returns(new[]
                {
                    new DateTime(2018, 12, 03).Add(startTime),
                    new DateTime(2018, 12, 17).Add(startTime),
                    new DateTime(2018, 12, 31).Add(startTime),
                    new DateTime(2019, 01, 14).Add(startTime),
                    new DateTime(2019, 01, 28).Add(startTime),
                    new DateTime(2019, 02, 11).Add(startTime),
                    new DateTime(2019, 02, 25).Add(startTime),
                });

            yield return new TestCaseData(DaysOfTheWeek.Weekend, 1, DayOfWeek.Monday, new DateTime(2018, 12, 02).Add(startTime), 7)
                .Returns(new[]
                {
                    new DateTime(2018, 12, 02).Add(startTime),
                    new DateTime(2018, 12, 08).Add(startTime),
                    new DateTime(2018, 12, 09).Add(startTime),
                    new DateTime(2018, 12, 15).Add(startTime),
                    new DateTime(2018, 12, 16).Add(startTime),
                    new DateTime(2018, 12, 22).Add(startTime),
                    new DateTime(2018, 12, 23).Add(startTime),
                });

            yield return new TestCaseData(DaysOfTheWeek.Weekend, 2, DayOfWeek.Sunday, new DateTime(2018, 12, 02).Add(startTime), 7)
                .Returns(new[]
                {
                    new DateTime(2018, 12, 02).Add(startTime),
                    new DateTime(2018, 12, 08).Add(startTime),
                    new DateTime(2018, 12, 16).Add(startTime),
                    new DateTime(2018, 12, 22).Add(startTime),
                    new DateTime(2018, 12, 30).Add(startTime),
                    new DateTime(2019, 01, 05).Add(startTime),
                    new DateTime(2019, 01, 13).Add(startTime),
                });
        }

        [TestCaseSource(nameof(TestData))]
        public IEnumerable<DateTime> Recurrences(DaysOfTheWeek daysOfWeek, int interval, DayOfWeek firstDayOfWeek, DateTime start, int count)
        {
            var pattern = Recurrent.Weekly(daysOfWeek, interval, firstDayOfWeek);
            return pattern.GetRecurrencesStartingAt(start).Take(count).ToArray();
        }

        [Test]
        public void Recurrences_All()
        {
            var pattern = Recurrent.Weekly(DaysOfTheWeek.Wednesday);
            var start = DateTime.SpecifyKind(DateTime.MinValue.AddTicks(123456789), DateTimeKind.Utc);

            Assert.That(pattern.GetRecurrencesStartingAt(start).Select(date => date.Kind), Is.All.EqualTo(start.Kind));
            Assert.That(pattern.GetRecurrencesStartingAt(start).Select(date => date.TimeOfDay), Is.All.EqualTo(start.TimeOfDay));
            Assert.That(pattern.GetRecurrencesStartingAt(start).Select(date => date.DayOfWeek), Is.All.EqualTo(DayOfWeek.Wednesday));
        }

        [Test]
        public void Object_Equality()
        {
            var pattern1 = Recurrent.Weekly(DaysOfTheWeek.Weekend, interval: 2, firstDayOfWeek: DayOfWeek.Monday);
            var pattern2 = Recurrent.Weekly(DaysOfTheWeek.Weekend, interval: 2, firstDayOfWeek: DayOfWeek.Monday);

            Assert.That(pattern1, Is.EqualTo(pattern2));
        }

        [Test]
        public void Object_Inequality()
        {
            var pattern1 = Recurrent.Weekly(DaysOfTheWeek.Weekend, interval: 1, firstDayOfWeek: DayOfWeek.Monday);
            var pattern2 = Recurrent.Weekly(DaysOfTheWeek.Weekend, interval: 2, firstDayOfWeek: DayOfWeek.Monday);
            var pattern3 = Recurrent.Weekly(DaysOfTheWeek.Weekday, interval: 2, firstDayOfWeek: DayOfWeek.Monday);
            var pattern4 = Recurrent.Weekly(DaysOfTheWeek.Weekday, interval: 2, firstDayOfWeek: DayOfWeek.Sunday);

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
            var pattern1 = Recurrent.Weekly(DaysOfTheWeek.Weekend, interval: 2, firstDayOfWeek: DayOfWeek.Monday);
            var pattern2 = Recurrent.Weekly(DaysOfTheWeek.Weekend, interval: 2, firstDayOfWeek: DayOfWeek.Monday);

            Assert.That(pattern1.GetHashCode() == pattern2.GetHashCode());
        }

        [Test]
        public void HashCode_Inequality()
        {
            var pattern1 = Recurrent.Weekly(DaysOfTheWeek.Weekend, interval: 1, firstDayOfWeek: DayOfWeek.Monday);
            var pattern2 = Recurrent.Weekly(DaysOfTheWeek.Weekend, interval: 2, firstDayOfWeek: DayOfWeek.Monday);
            var pattern3 = Recurrent.Weekly(DaysOfTheWeek.Weekday, interval: 2, firstDayOfWeek: DayOfWeek.Monday);
            var pattern4 = Recurrent.Weekly(DaysOfTheWeek.Weekday, interval: 2, firstDayOfWeek: DayOfWeek.Sunday);

            Assert.That(pattern1.GetHashCode() != pattern2.GetHashCode());
            Assert.That(pattern1.GetHashCode() != pattern3.GetHashCode());
            Assert.That(pattern1.GetHashCode() != pattern4.GetHashCode());
            Assert.That(pattern2.GetHashCode() != pattern3.GetHashCode());
            Assert.That(pattern2.GetHashCode() != pattern4.GetHashCode());
            Assert.That(pattern3.GetHashCode() != pattern4.GetHashCode());
        }
    }
}