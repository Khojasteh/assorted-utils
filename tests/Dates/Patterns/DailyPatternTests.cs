using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assorted.Utils.Dates.Patterns.Tests
{
    [TestFixture]
    [TestOf(typeof(DailyPattern))]
    public class DailyPatternTests
    {
        static IEnumerable<TestCaseData> TestData()
        {
            var startTime = TimeSpan.FromDays(0.123456789);

            yield return new TestCaseData(1, new DateTime(2020, 01, 01).Add(startTime), 7)
                .Returns(new[]
                {
                    new DateTime(2020, 01, 01).Add(startTime),
                    new DateTime(2020, 01, 02).Add(startTime),
                    new DateTime(2020, 01, 03).Add(startTime),
                    new DateTime(2020, 01, 04).Add(startTime),
                    new DateTime(2020, 01, 05).Add(startTime),
                    new DateTime(2020, 01, 06).Add(startTime),
                    new DateTime(2020, 01, 07).Add(startTime),
                });

            yield return new TestCaseData(2, new DateTime(2020, 1, 1).Add(startTime), 7)
                .Returns(new[]
                {
                    new DateTime(2020, 01, 01).Add(startTime),
                    new DateTime(2020, 01, 03).Add(startTime),
                    new DateTime(2020, 01, 05).Add(startTime),
                    new DateTime(2020, 01, 07).Add(startTime),
                    new DateTime(2020, 01, 09).Add(startTime),
                    new DateTime(2020, 01, 11).Add(startTime),
                    new DateTime(2020, 01, 13).Add(startTime),
                });
        }

        [TestCaseSource(nameof(TestData))]
        public IEnumerable<DateTime> Recurrences(int interval, DateTime start, int count)
        {
            var pattern = Recurrent.Daily(interval);
            return pattern.GetRecurrencesStartingAt(start).Take(count).ToArray();
        }

        [Test]
        public void Recurrences_All()
        {
            var pattern = Recurrent.Daily();
            var start = DateTime.SpecifyKind(DateTime.MinValue.AddTicks(123456789), DateTimeKind.Utc);

            Assert.That(pattern.GetRecurrencesStartingAt(start).Select(date => date.Kind), Is.All.EqualTo(start.Kind));
            Assert.That(pattern.GetRecurrencesStartingAt(start).Select(date => date.TimeOfDay), Is.All.EqualTo(start.TimeOfDay));
        }

        [Test]
        public void Object_Equality()
        {
            var pattern1 = Recurrent.Daily(interval: 2);
            var pattern2 = Recurrent.Daily(interval: 2);

            Assert.That(pattern1, Is.EqualTo(pattern2));
        }

        [Test]
        public void Object_Inequality()
        {
            var pattern1 = Recurrent.Daily(interval: 1);
            var pattern2 = Recurrent.Daily(interval: 2);

            Assert.That(pattern1, Is.Not.EqualTo(pattern2));
        }

        [Test]
        public void HashCode_Equality()
        {
            var pattern1 = Recurrent.Daily(interval: 2);
            var pattern2 = Recurrent.Daily(interval: 2);

            Assert.That(pattern1.GetHashCode() == pattern2.GetHashCode());
        }

        [Test]
        public void HashCode_Inequality()
        {
            var pattern1 = Recurrent.Daily(interval: 1);
            var pattern2 = Recurrent.Daily(interval: 2);

            Assert.That(pattern1.GetHashCode() != pattern2.GetHashCode());
        }
    }
}