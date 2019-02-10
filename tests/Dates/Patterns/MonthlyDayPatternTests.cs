using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assorted.Utils.Dates.Patterns.Tests
{
    [TestFixture]
    [TestOf(typeof(MonthlyDayPattern))]
    public class MonthlyDayPatternTests
    {
        static IEnumerable<TestCaseData> TestData()
        {
            var startTime = TimeSpan.FromDays(0.123456789);

            yield return new TestCaseData(01, 1, new DateTime(2018, 12, 02).Add(startTime), 7)
                .Returns(new[]
                {
                    new DateTime(2019, 01, 01).Add(startTime),
                    new DateTime(2019, 02, 01).Add(startTime),
                    new DateTime(2019, 03, 01).Add(startTime),
                    new DateTime(2019, 04, 01).Add(startTime),
                    new DateTime(2019, 05, 01).Add(startTime),
                    new DateTime(2019, 06, 01).Add(startTime),
                    new DateTime(2019, 07, 01).Add(startTime),
                });

            yield return new TestCaseData(01, 2, new DateTime(2018, 12, 02).Add(startTime), 7)
                .Returns(new[]
                {
                    new DateTime(2019, 02, 01).Add(startTime),
                    new DateTime(2019, 04, 01).Add(startTime),
                    new DateTime(2019, 06, 01).Add(startTime),
                    new DateTime(2019, 08, 01).Add(startTime),
                    new DateTime(2019, 10, 01).Add(startTime),
                    new DateTime(2019, 12, 01).Add(startTime),
                    new DateTime(2020, 02, 01).Add(startTime),
                });

            yield return new TestCaseData(31, 1, new DateTime(2019, 01, 01).Add(startTime), 7)
                .Returns(new[]
                {
                    new DateTime(2019, 01, 31).Add(startTime),
                    new DateTime(2019, 03, 31).Add(startTime),
                    new DateTime(2019, 05, 31).Add(startTime),
                    new DateTime(2019, 07, 31).Add(startTime),
                    new DateTime(2019, 08, 31).Add(startTime),
                    new DateTime(2019, 10, 31).Add(startTime),
                    new DateTime(2019, 12, 31).Add(startTime),
                });

            yield return new TestCaseData(29, 1, new DateTime(2018, 12, 30).Add(startTime), 14)
                .Returns(new[]
                {
                    new DateTime(2019, 01, 29).Add(startTime),
                    new DateTime(2019, 03, 29).Add(startTime),
                    new DateTime(2019, 04, 29).Add(startTime),
                    new DateTime(2019, 05, 29).Add(startTime),
                    new DateTime(2019, 06, 29).Add(startTime),
                    new DateTime(2019, 07, 29).Add(startTime),
                    new DateTime(2019, 08, 29).Add(startTime),
                    new DateTime(2019, 09, 29).Add(startTime),
                    new DateTime(2019, 10, 29).Add(startTime),
                    new DateTime(2019, 11, 29).Add(startTime),
                    new DateTime(2019, 12, 29).Add(startTime),
                    new DateTime(2020, 01, 29).Add(startTime),
                    new DateTime(2020, 02, 29).Add(startTime),
                    new DateTime(2020, 03, 29).Add(startTime),
                });

            yield return new TestCaseData(29, 2, new DateTime(2018, 12, 30).Add(startTime), 7)
                .Returns(new[]
                {
                    new DateTime(2019, 04, 29).Add(startTime),
                    new DateTime(2019, 06, 29).Add(startTime),
                    new DateTime(2019, 08, 29).Add(startTime),
                    new DateTime(2019, 10, 29).Add(startTime),
                    new DateTime(2019, 12, 29).Add(startTime),
                    new DateTime(2020, 02, 29).Add(startTime),
                    new DateTime(2020, 04, 29).Add(startTime),
                });
        }

        [TestCaseSource(nameof(TestData))]
        public IEnumerable<DateTime> Recurrences(int dayOfMonth, int interval, DateTime start, int count)
        {
            var pattern = Recurrent.Monthly(dayOfMonth, interval);
            return pattern.GetRecurrencesStartingAt(start).Take(count).ToArray();
        }

        [Test]
        public void Recurrences_All()
        {
            var pattern = Recurrent.Monthly(15);
            var start = DateTime.SpecifyKind(DateTime.MinValue.AddTicks(123456789), DateTimeKind.Utc);

            Assert.That(pattern.GetRecurrencesStartingAt(start).Select(date => date.Kind), Is.All.EqualTo(start.Kind));
            Assert.That(pattern.GetRecurrencesStartingAt(start).Select(date => date.TimeOfDay), Is.All.EqualTo(start.TimeOfDay));
            Assert.That(pattern.GetRecurrencesStartingAt(start).Select(date => date.Day), Is.All.EqualTo(15));
        }

        [Test]
        public void Object_Equality()
        {
            var pattern1 = Recurrent.Monthly(dayOfMonth: 02, interval: 2);
            var pattern2 = Recurrent.Monthly(dayOfMonth: 02, interval: 2);

            Assert.That(pattern1, Is.EqualTo(pattern2));
        }

        [Test]
        public void Object_Inequality()
        {
            var pattern1 = Recurrent.Monthly(dayOfMonth: 01, interval: 1);
            var pattern2 = Recurrent.Monthly(dayOfMonth: 02, interval: 2);
            var pattern3 = Recurrent.Monthly(dayOfMonth: 02, interval: 1);

            Assert.That(pattern1, Is.Not.EqualTo(pattern2));
            Assert.That(pattern1, Is.Not.EqualTo(pattern3));
            Assert.That(pattern2, Is.Not.EqualTo(pattern3));
        }

        [Test]
        public void HashCode_Equality()
        {
            var pattern1 = Recurrent.Monthly(dayOfMonth: 02, interval: 2);
            var pattern2 = Recurrent.Monthly(dayOfMonth: 02, interval: 2);

            Assert.That(pattern1.GetHashCode() == pattern2.GetHashCode());
        }

        [Test]
        public void HashCode_Inequality()
        {
            var pattern1 = Recurrent.Monthly(dayOfMonth: 01, interval: 1);
            var pattern2 = Recurrent.Monthly(dayOfMonth: 02, interval: 2);
            var pattern3 = Recurrent.Monthly(dayOfMonth: 02, interval: 1);

            Assert.That(pattern1.GetHashCode() != pattern2.GetHashCode());
            Assert.That(pattern1.GetHashCode() != pattern3.GetHashCode());
            Assert.That(pattern2.GetHashCode() != pattern3.GetHashCode());
        }
    }
}