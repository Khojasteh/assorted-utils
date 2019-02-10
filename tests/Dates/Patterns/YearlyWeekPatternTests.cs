using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assorted.Utils.Dates.Patterns.Tests
{
    [TestFixture]
    [TestOf(typeof(YearlyWeekPattern))]
    public class YearlyWeekPatternTests
    {
        static IEnumerable<TestCaseData> TestData()
        {
            var startTime = TimeSpan.FromDays(0.123456789);

            yield return new TestCaseData(WeekOfMonth.First, DaysOfTheWeek.Monday, MonthOfYear.May, 1, new DateTime(2019, 01, 01).Add(startTime), 3)
                .Returns(new[]
                {
                    new DateTime(2019, 05, 06).Add(startTime),
                    new DateTime(2020, 05, 04).Add(startTime),
                    new DateTime(2021, 05, 03).Add(startTime),
                });

            yield return new TestCaseData(WeekOfMonth.First, DaysOfTheWeek.Monday, MonthOfYear.May, 2, new DateTime(2019, 06, 01).Add(startTime), 3)
                .Returns(new[]
                {
                    new DateTime(2021, 05, 03).Add(startTime),
                    new DateTime(2023, 05, 01).Add(startTime),
                    new DateTime(2025, 05, 05).Add(startTime),
                });

            yield return new TestCaseData(WeekOfMonth.Last, DaysOfTheWeek.Weekend, MonthOfYear.Auguest, 1, new DateTime(2019, 01, 01).Add(startTime), 3)
                .Returns(new[]
                {
                    new DateTime(2019, 08, 31).Add(startTime),
                    new DateTime(2020, 08, 30).Add(startTime),
                    new DateTime(2021, 08, 29).Add(startTime),
                });

            yield return new TestCaseData(WeekOfMonth.Last, DaysOfTheWeek.Weekend, MonthOfYear.Auguest, 2, new DateTime(2019, 01, 01).Add(startTime), 3)
                .Returns(new[]
                {
                    new DateTime(2019, 08, 31).Add(startTime),
                    new DateTime(2021, 08, 29).Add(startTime),
                    new DateTime(2023, 08, 27).Add(startTime),
                });
        }

        [TestCaseSource(nameof(TestData))]
        public IEnumerable<DateTime> Recurrences(WeekOfMonth weekOfMonth, DaysOfTheWeek daysOfWeek, MonthOfYear monthOfYear, int interval, DateTime start, int count)
        {
            var pattern = Recurrent.Yearly(weekOfMonth, daysOfWeek, monthOfYear, interval);
            return pattern.GetRecurrencesStartingAt(start).Take(count).ToArray();
        }

        [Test]
        public void Recurrences_All()
        {
            var pattern = Recurrent.Yearly(WeekOfMonth.Second, DaysOfTheWeek.Wednesday, MonthOfYear.October);
            var start = DateTime.SpecifyKind(DateTime.MinValue.AddTicks(123456789), DateTimeKind.Utc);

            Assert.That(pattern.GetRecurrencesStartingAt(start).Select(date => date.Kind), Is.All.EqualTo(start.Kind));
            Assert.That(pattern.GetRecurrencesStartingAt(start).Select(date => date.TimeOfDay), Is.All.EqualTo(start.TimeOfDay));
            Assert.That(pattern.GetRecurrencesStartingAt(start).Select(date => date.DayOfWeek), Is.All.EqualTo(DayOfWeek.Wednesday));
            Assert.That(pattern.GetRecurrencesStartingAt(start).Select(date => date.DayOfWeekInstance()), Is.All.EqualTo(WeekOfMonth.Second));
            Assert.That(pattern.GetRecurrencesStartingAt(start).Select(date => date.Month), Is.All.EqualTo(10));
        }

        [Test]
        public void Object_Equality()
        {
            var pattern1 = Recurrent.Yearly(WeekOfMonth.First, DaysOfTheWeek.Weekend, MonthOfYear.January, interval: 1);
            var pattern2 = Recurrent.Yearly(WeekOfMonth.First, DaysOfTheWeek.Weekend, MonthOfYear.January, interval: 1);

            Assert.That(pattern1, Is.EqualTo(pattern2));
        }

        [Test]
        public void Object_Inequality()
        {
            var pattern1 = Recurrent.Yearly(WeekOfMonth.First, DaysOfTheWeek.Weekend, MonthOfYear.June, interval: 1);
            var pattern2 = Recurrent.Yearly(WeekOfMonth.First, DaysOfTheWeek.Weekday, MonthOfYear.June, interval: 1);
            var pattern3 = Recurrent.Yearly(WeekOfMonth.Last, DaysOfTheWeek.Weekend, MonthOfYear.June, interval: 1);
            var pattern4 = Recurrent.Yearly(WeekOfMonth.Last, DaysOfTheWeek.Weekend, MonthOfYear.June, interval: 2);
            var pattern5 = Recurrent.Yearly(WeekOfMonth.Last, DaysOfTheWeek.Weekend, MonthOfYear.March, interval: 2);

            Assert.That(pattern1, Is.Not.EqualTo(pattern2));
            Assert.That(pattern1, Is.Not.EqualTo(pattern3));
            Assert.That(pattern1, Is.Not.EqualTo(pattern4));
            Assert.That(pattern1, Is.Not.EqualTo(pattern5));
            Assert.That(pattern2, Is.Not.EqualTo(pattern3));
            Assert.That(pattern2, Is.Not.EqualTo(pattern4));
            Assert.That(pattern2, Is.Not.EqualTo(pattern5));
            Assert.That(pattern3, Is.Not.EqualTo(pattern4));
            Assert.That(pattern3, Is.Not.EqualTo(pattern5));
            Assert.That(pattern4, Is.Not.EqualTo(pattern5));
        }

        [Test]
        public void HashCode_Equality()
        {
            var pattern1 = Recurrent.Yearly(WeekOfMonth.First, DaysOfTheWeek.Weekend, MonthOfYear.November, interval: 1);
            var pattern2 = Recurrent.Yearly(WeekOfMonth.First, DaysOfTheWeek.Weekend, MonthOfYear.November, interval: 1);

            Assert.That(pattern1.GetHashCode() == pattern2.GetHashCode());
        }

        [Test]
        public void HashCode_Inequality()
        {
            var pattern1 = Recurrent.Yearly(WeekOfMonth.First, DaysOfTheWeek.Weekend, MonthOfYear.June, interval: 1);
            var pattern2 = Recurrent.Yearly(WeekOfMonth.First, DaysOfTheWeek.Weekday, MonthOfYear.June, interval: 1);
            var pattern3 = Recurrent.Yearly(WeekOfMonth.Last, DaysOfTheWeek.Weekend, MonthOfYear.June, interval: 1);
            var pattern4 = Recurrent.Yearly(WeekOfMonth.Last, DaysOfTheWeek.Weekend, MonthOfYear.June, interval: 2);
            var pattern5 = Recurrent.Yearly(WeekOfMonth.Last, DaysOfTheWeek.Weekend, MonthOfYear.March, interval: 2);

            Assert.That(pattern1.GetHashCode() != pattern2.GetHashCode());
            Assert.That(pattern1.GetHashCode() != pattern3.GetHashCode());
            Assert.That(pattern1.GetHashCode() != pattern4.GetHashCode());
            Assert.That(pattern1.GetHashCode() != pattern5.GetHashCode());
            Assert.That(pattern2.GetHashCode() != pattern3.GetHashCode());
            Assert.That(pattern2.GetHashCode() != pattern4.GetHashCode());
            Assert.That(pattern2.GetHashCode() != pattern5.GetHashCode());
            Assert.That(pattern3.GetHashCode() != pattern4.GetHashCode());
            Assert.That(pattern3.GetHashCode() != pattern5.GetHashCode());
            Assert.That(pattern4.GetHashCode() != pattern5.GetHashCode());
        }
    }
}