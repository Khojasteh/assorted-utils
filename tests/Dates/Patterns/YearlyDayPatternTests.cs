using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assorted.Utils.Dates.Patterns.Tests
{
    [TestFixture]
    [TestOf(typeof(YearlyDayPattern))]
    public class YearlyDayPatternTests
    {
        static IEnumerable<TestCaseData> TestData()
        {
            var startTime = TimeSpan.FromDays(0.123456789);

            yield return new TestCaseData(256, 1, new DateTime(2018, 01, 01).Add(startTime), 5)
                .Returns(new[]
                {
                    new DateTime(2018, 09, 13).Add(startTime),
                    new DateTime(2019, 09, 13).Add(startTime),
                    new DateTime(2020, 09, 12).Add(startTime),
                    new DateTime(2021, 09, 13).Add(startTime),
                    new DateTime(2022, 09, 13).Add(startTime),
                });

            yield return new TestCaseData(256, 2, new DateTime(2018, 01, 01).Add(startTime), 3)
                .Returns(new[]
                {
                    new DateTime(2018, 09, 13).Add(startTime),
                    new DateTime(2020, 09, 12).Add(startTime),
                    new DateTime(2022, 09, 13).Add(startTime),
                });

            yield return new TestCaseData(366, 1, new DateTime(2018, 01, 01).Add(startTime), 3)
                .Returns(new[]
                {
                    new DateTime(2020, 12, 31).Add(startTime),
                    new DateTime(2024, 12, 31).Add(startTime),
                    new DateTime(2028, 12, 31).Add(startTime),
                });

            yield return new TestCaseData(366, 2, new DateTime(2018, 01, 01).Add(startTime), 3)
                .Returns(new[]
                {
                    new DateTime(2020, 12, 31).Add(startTime),
                    new DateTime(2024, 12, 31).Add(startTime),
                    new DateTime(2028, 12, 31).Add(startTime),
                });

            yield return new TestCaseData(366, 3, new DateTime(2018, 01, 01).Add(startTime), 3)
                .Returns(new[]
                {
                    new DateTime(2024, 12, 31).Add(startTime),
                    new DateTime(2036, 12, 31).Add(startTime),
                    new DateTime(2048, 12, 31).Add(startTime),
                });
        }

        [TestCaseSource(nameof(TestData))]
        public IEnumerable<DateTime> Recurrences(int dayOfYear, int interval, DateTime start, int count)
        {
            var pattern = Recurrent.Yearly(dayOfYear, interval);
            return pattern.GetRecurrencesStartingAt(start).Take(count).ToArray();
        }

        [Test]
        public void Recurrences_All()
        {
            var pattern = Recurrent.Yearly(dayOfYear: 333);
            var start = DateTime.SpecifyKind(DateTime.MinValue.AddTicks(123456789), DateTimeKind.Utc);

            Assert.That(pattern.GetRecurrencesStartingAt(start).Select(date => date.Kind), Is.All.EqualTo(start.Kind));
            Assert.That(pattern.GetRecurrencesStartingAt(start).Select(date => date.TimeOfDay), Is.All.EqualTo(start.TimeOfDay));
            Assert.That(pattern.GetRecurrencesStartingAt(start).Select(date => date.DayOfYear), Is.All.EqualTo(333));
        }

        [Test]
        public void Object_Equality()
        {
            var pattern1 = Recurrent.Yearly(dayOfYear: 123, interval: 2);
            var pattern2 = Recurrent.Yearly(dayOfYear: 123, interval: 2);

            Assert.That(pattern1, Is.EqualTo(pattern2));
        }

        [Test]
        public void Object_Inequality()
        {
            var pattern1 = Recurrent.Yearly(dayOfYear: 123, interval: 1);
            var pattern2 = Recurrent.Yearly(dayOfYear: 321, interval: 2);

            Assert.That(pattern1, Is.Not.EqualTo(pattern2));
        }

        [Test]
        public void HashCode_Equality()
        {
            var pattern1 = Recurrent.Yearly(dayOfYear: 123, interval: 2);
            var pattern2 = Recurrent.Yearly(dayOfYear: 123, interval: 2);

            Assert.That(pattern1.GetHashCode() == pattern2.GetHashCode());
        }

        [Test]
        public void HashCode_Inequality()
        {
            var pattern1 = Recurrent.Yearly(dayOfYear: 123, interval: 1);
            var pattern2 = Recurrent.Yearly(dayOfYear: 321, interval: 2);

            Assert.That(pattern1.GetHashCode() != pattern2.GetHashCode());
        }
    }
}