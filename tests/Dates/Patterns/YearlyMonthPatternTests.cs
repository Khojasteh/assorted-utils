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
    [TestOf(typeof(YearlyMonthPattern))]
    public class YearlyMonthPatternTests
    {
        static IEnumerable<TestCaseData> TestData()
        {
            var startTime = TimeSpan.FromDays(0.123456789);

            yield return new TestCaseData(MonthOfYear.April, 01, 1, new DateTime(2018, 04, 01).Add(startTime), 3)
                .Returns(new[]
                {
                    new DateTime(2018, 04, 01).Add(startTime),
                    new DateTime(2019, 04, 01).Add(startTime),
                    new DateTime(2020, 04, 01).Add(startTime),
                });

            yield return new TestCaseData(MonthOfYear.April, 01, 2, new DateTime(2018, 04, 01).Add(startTime), 3)
                .Returns(new[]
                {
                    new DateTime(2018, 04, 01).Add(startTime),
                    new DateTime(2020, 04, 01).Add(startTime),
                    new DateTime(2022, 04, 01).Add(startTime),
                });

            yield return new TestCaseData(MonthOfYear.July, 01, 1, new DateTime(2018, 07, 02).Add(startTime), 3)
                .Returns(new[]
                {
                    new DateTime(2019, 07, 01).Add(startTime),
                    new DateTime(2020, 07, 01).Add(startTime),
                    new DateTime(2021, 07, 01).Add(startTime),
                });

            yield return new TestCaseData(MonthOfYear.July, 01, 2, new DateTime(2018, 07, 02).Add(startTime), 3)
                .Returns(new[]
                {
                    new DateTime(2020, 07, 01).Add(startTime),
                    new DateTime(2022, 07, 01).Add(startTime),
                    new DateTime(2024, 07, 01).Add(startTime),
                });

            yield return new TestCaseData(MonthOfYear.February, 29, 1, new DateTime(2018, 01, 01).Add(startTime), 3)
                .Returns(new[]
                {
                    new DateTime(2020, 02, 29).Add(startTime),
                    new DateTime(2024, 02, 29).Add(startTime),
                    new DateTime(2028, 02, 29).Add(startTime),
                });

            yield return new TestCaseData(MonthOfYear.February, 29, 2, new DateTime(2018, 01, 01).Add(startTime), 3)
                .Returns(new[]
                {
                    new DateTime(2020, 02, 29).Add(startTime),
                    new DateTime(2024, 02, 29).Add(startTime),
                    new DateTime(2028, 02, 29).Add(startTime),
                });

            yield return new TestCaseData(MonthOfYear.February, 29, 3, new DateTime(2018, 01, 01).Add(startTime), 3)
                .Returns(new[]
                {
                    new DateTime(2024, 02, 29).Add(startTime),
                    new DateTime(2036, 02, 29).Add(startTime),
                    new DateTime(2048, 02, 29).Add(startTime),
                });
        }

        [TestCaseSource(nameof(TestData))]
        public IEnumerable<DateTime> Recurrences(MonthOfYear monthOfYear, int dayOfMonth, int interval, DateTime start, int count)
        {
            var pattern = Recurrent.Yearly(monthOfYear, dayOfMonth, interval);
            return pattern.GetRecurrencesStartingAt(start).Take(count).ToArray();
        }

        [Test]
        public void Recurrences_All()
        {
            var pattern = Recurrent.Yearly(MonthOfYear.February, 29);
            var start = DateTime.SpecifyKind(DateTime.MinValue.AddTicks(123456789), DateTimeKind.Utc);

            Assert.That(pattern.GetRecurrencesStartingAt(start).Select(date => date.Kind), Is.All.EqualTo(start.Kind));
            Assert.That(pattern.GetRecurrencesStartingAt(start).Select(date => date.TimeOfDay), Is.All.EqualTo(start.TimeOfDay));
            Assert.That(pattern.GetRecurrencesStartingAt(start).Select(date => date.Month), Is.All.EqualTo(02));
            Assert.That(pattern.GetRecurrencesStartingAt(start).Select(date => date.Day), Is.All.EqualTo(29));
        }

        [Test]
        public void Object_Equality()
        {
            var pattern1 = Recurrent.Yearly(MonthOfYear.April, dayOfMonth: 02, interval: 2);
            var pattern2 = Recurrent.Yearly(MonthOfYear.April, dayOfMonth: 02, interval: 2);

            Assert.That(pattern1, Is.EqualTo(pattern2));
        }

        [Test]
        public void Object_Inequality()
        {
            var pattern1 = Recurrent.Yearly(MonthOfYear.December, dayOfMonth: 01, interval: 1);
            var pattern2 = Recurrent.Yearly(MonthOfYear.April, dayOfMonth: 02, interval: 2);
            var pattern3 = Recurrent.Yearly(MonthOfYear.April, dayOfMonth: 02, interval: 1);

            Assert.That(pattern1, Is.Not.EqualTo(pattern2));
            Assert.That(pattern1, Is.Not.EqualTo(pattern3));
            Assert.That(pattern2, Is.Not.EqualTo(pattern3));
        }

        [Test]
        public void HashCode_Equality()
        {
            var pattern1 = Recurrent.Yearly(MonthOfYear.April, dayOfMonth: 02, interval: 2);
            var pattern2 = Recurrent.Yearly(MonthOfYear.April, dayOfMonth: 02, interval: 2);

            Assert.That(pattern1.GetHashCode() == pattern2.GetHashCode());
        }

        [Test]
        public void HashCode_Inequality()
        {
            var pattern1 = Recurrent.Yearly(MonthOfYear.December, dayOfMonth: 01, interval: 1);
            var pattern2 = Recurrent.Yearly(MonthOfYear.April, dayOfMonth: 02, interval: 2);
            var pattern3 = Recurrent.Yearly(MonthOfYear.April, dayOfMonth: 02, interval: 1);

            Assert.That(pattern1.GetHashCode() != pattern2.GetHashCode());
            Assert.That(pattern1.GetHashCode() != pattern3.GetHashCode());
            Assert.That(pattern2.GetHashCode() != pattern3.GetHashCode());
        }
    }
}