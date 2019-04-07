// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Assorted.Utils.Dates.Tests
{
    [TestFixture]
    [TestOf(typeof(DateTimeExtensions))]
    public class DateTimeExtensionsTests
    {
        static IEnumerable<DateTime> SampleDateTimes()
        {
            yield return DateTime.Now;
            yield return DateTime.UtcNow;
            yield return new DateTime(0xfedcba987654321);
            yield return new DateTime(1990, 01, 28, 08, 26, 01, 123, DateTimeKind.Unspecified);
            yield return new DateTime(2000, 02, 29, 09, 27, 02, 456, DateTimeKind.Local);
            yield return new DateTime(2010, 03, 30, 10, 28, 59, 789, DateTimeKind.Utc);
            yield return new DateTime(2020, 04, 01, 11, 29, 58, 123, DateTimeKind.Unspecified);
            yield return new DateTime(2021, 05, 02, 12, 30, 47, 456, DateTimeKind.Local);
            yield return new DateTime(2022, 06, 03, 13, 31, 46, 789, DateTimeKind.Utc);
            yield return new DateTime(1923, 07, 04, 14, 32, 35, 123, DateTimeKind.Unspecified);
            yield return new DateTime(2024, 08, 14, 15, 33, 34, 456, DateTimeKind.Local);
            yield return new DateTime(2025, 09, 15, 20, 34, 23, 789, DateTimeKind.Utc);
            yield return new DateTime(2026, 10, 16, 21, 35, 22, 123, DateTimeKind.Unspecified);
            yield return new DateTime(2027, 11, 17, 22, 36, 11, 356, DateTimeKind.Local);
            yield return new DateTime(2028, 12, 18, 23, 37, 02, 789, DateTimeKind.Utc);
        }

        [TestCase(1996, 1, 1)]
        [TestCase(2000, 2, 2)]
        [TestCase(2016, 3, 3)]
        [TestCase(2020, 4, 4)]
        [TestCase(2096, 5, 5)]
        [TestCase(2104, 6, 6)]
        public void IsInLeapYear(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);

            Assert.That(date.IsInLeapYear(), Is.True);
        }

        [TestCase(2002, 1, 1)]
        [TestCase(2018, 2, 2)]
        [TestCase(2019, 3, 3)]
        [TestCase(2100, 4, 4)]
        public void IsNotInLeapYear(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);

            Assert.That(date.IsInLeapYear(), Is.False);
        }

        [TestCaseSource(nameof(SampleDateTimes))]
        public void ReplaceDate(DateTime datetime)
        {
            var newDate = new DateTime(2018, 11, 17);
            var result = datetime.ReplaceDate(newDate);

            Assert.That(result.Kind, Is.EqualTo(datetime.Kind));
            Assert.That(result.TimeOfDay, Is.EqualTo(datetime.TimeOfDay));
            Assert.That(result.Date, Is.EqualTo(newDate));
        }

        [TestCaseSource(nameof(SampleDateTimes))]
        public void ReplaceTime(DateTime datetime)
        {
            var newTime = new TimeSpan(11, 22, 33);
            var result = datetime.ReplaceTime(newTime);

            Assert.That(result.Kind, Is.EqualTo(datetime.Kind));
            Assert.That(result.Date, Is.EqualTo(datetime.Date));
            Assert.That(result.TimeOfDay, Is.EqualTo(newTime));
        }

        [TestCaseSource(nameof(SampleDateTimes))]
        public void StartOfMillisecond(DateTime datetime)
        {
            var result = datetime.StartOfMillisecond();

            Assert.That(result.Kind, Is.EqualTo(datetime.Kind));
            Assert.That(result.Date, Is.EqualTo(datetime.Date));
            Assert.That(result.TimeOfDay.Hours, Is.EqualTo(datetime.TimeOfDay.Hours));
            Assert.That(result.TimeOfDay.Minutes, Is.EqualTo(datetime.TimeOfDay.Minutes));
            Assert.That(result.TimeOfDay.Seconds, Is.EqualTo(datetime.TimeOfDay.Seconds));
            Assert.That(result.TimeOfDay.Milliseconds, Is.EqualTo(datetime.TimeOfDay.Milliseconds));
            Assert.That(result.TimeOfDay.Ticks % TimeSpan.TicksPerMillisecond, Is.Zero);
        }

        [TestCaseSource(nameof(SampleDateTimes))]
        public void EndOfMillisecond(DateTime datetime)
        {
            var result = datetime.EndOfMillisecond();

            Assert.That(result.Kind, Is.EqualTo(datetime.Kind));
            Assert.That(result.Date, Is.EqualTo(datetime.Date));
            Assert.That(result.TimeOfDay.Hours, Is.EqualTo(datetime.TimeOfDay.Hours));
            Assert.That(result.TimeOfDay.Minutes, Is.EqualTo(datetime.TimeOfDay.Minutes));
            Assert.That(result.TimeOfDay.Seconds, Is.EqualTo(datetime.TimeOfDay.Seconds));
            Assert.That(result.TimeOfDay.Milliseconds, Is.EqualTo(datetime.TimeOfDay.Milliseconds));
            Assert.That(result.TimeOfDay.Ticks % TimeSpan.TicksPerMillisecond, Is.EqualTo(TimeSpan.TicksPerMillisecond - 1));
        }

        [TestCaseSource(nameof(SampleDateTimes))]
        public void StartOfSecond(DateTime datetime)
        {
            var result = datetime.StartOfSecond();

            Assert.That(result.Kind, Is.EqualTo(datetime.Kind));
            Assert.That(result.Date, Is.EqualTo(datetime.Date));
            Assert.That(result.TimeOfDay.Hours, Is.EqualTo(datetime.TimeOfDay.Hours));
            Assert.That(result.TimeOfDay.Minutes, Is.EqualTo(datetime.TimeOfDay.Minutes));
            Assert.That(result.TimeOfDay.Seconds, Is.EqualTo(datetime.TimeOfDay.Seconds));
            Assert.That(result.TimeOfDay.Milliseconds, Is.Zero);
            Assert.That(result.TimeOfDay.Ticks % TimeSpan.TicksPerMillisecond, Is.Zero);
        }

        [TestCaseSource(nameof(SampleDateTimes))]
        public void EndOfSecond(DateTime datetime)
        {
            var result = datetime.EndOfSecond();

            Assert.That(result.Kind, Is.EqualTo(datetime.Kind));
            Assert.That(result.Date, Is.EqualTo(datetime.Date));
            Assert.That(result.TimeOfDay.Hours, Is.EqualTo(datetime.TimeOfDay.Hours));
            Assert.That(result.TimeOfDay.Minutes, Is.EqualTo(datetime.TimeOfDay.Minutes));
            Assert.That(result.TimeOfDay.Seconds, Is.EqualTo(datetime.TimeOfDay.Seconds));
            Assert.That(result.TimeOfDay.Milliseconds, Is.EqualTo(999));
            Assert.That(result.TimeOfDay.Ticks % TimeSpan.TicksPerMillisecond, Is.EqualTo(TimeSpan.TicksPerMillisecond - 1));
        }

        [TestCaseSource(nameof(SampleDateTimes))]
        public void StartOfMinute(DateTime datetime)
        {
            var result = datetime.StartOfMinute();

            Assert.That(result.Kind, Is.EqualTo(datetime.Kind));
            Assert.That(result.Date, Is.EqualTo(datetime.Date));
            Assert.That(result.TimeOfDay.Hours, Is.EqualTo(datetime.TimeOfDay.Hours));
            Assert.That(result.TimeOfDay.Minutes, Is.EqualTo(datetime.TimeOfDay.Minutes));
            Assert.That(result.TimeOfDay.Seconds, Is.Zero);
            Assert.That(result.TimeOfDay.Milliseconds, Is.Zero);
            Assert.That(result.TimeOfDay.Ticks % TimeSpan.TicksPerMillisecond, Is.Zero);
        }

        [TestCaseSource(nameof(SampleDateTimes))]
        public void EndOfMinute(DateTime datetime)
        {
            var result = datetime.EndOfMinute();

            Assert.That(result.Kind, Is.EqualTo(datetime.Kind));
            Assert.That(result.Date, Is.EqualTo(datetime.Date));
            Assert.That(result.TimeOfDay.Hours, Is.EqualTo(datetime.TimeOfDay.Hours));
            Assert.That(result.TimeOfDay.Minutes, Is.EqualTo(datetime.TimeOfDay.Minutes));
            Assert.That(result.TimeOfDay.Seconds, Is.EqualTo(59));
            Assert.That(result.TimeOfDay.Milliseconds, Is.EqualTo(999));
            Assert.That(result.TimeOfDay.Ticks % TimeSpan.TicksPerMillisecond, Is.EqualTo(TimeSpan.TicksPerMillisecond - 1));
        }

        [TestCaseSource(nameof(SampleDateTimes))]
        public void StartOfHour(DateTime datetime)
        {
            var result = datetime.StartOfHour();

            Assert.That(result.Kind, Is.EqualTo(datetime.Kind));
            Assert.That(result.Date, Is.EqualTo(datetime.Date));
            Assert.That(result.Kind, Is.EqualTo(datetime.Kind));
            Assert.That(result.Date, Is.EqualTo(datetime.Date));
            Assert.That(result.TimeOfDay.Hours, Is.EqualTo(datetime.TimeOfDay.Hours));
            Assert.That(result.TimeOfDay.Minutes, Is.Zero);
            Assert.That(result.TimeOfDay.Seconds, Is.Zero);
            Assert.That(result.TimeOfDay.Milliseconds, Is.Zero);
            Assert.That(result.TimeOfDay.Ticks % TimeSpan.TicksPerMillisecond, Is.Zero);
        }

        [TestCaseSource(nameof(SampleDateTimes))]
        public void EndOfHour(DateTime datetime)
        {
            var result = datetime.EndOfHour();

            Assert.That(result.Kind, Is.EqualTo(datetime.Kind));
            Assert.That(result.Date, Is.EqualTo(datetime.Date));
            Assert.That(result.TimeOfDay.Hours, Is.EqualTo(datetime.TimeOfDay.Hours));
            Assert.That(result.TimeOfDay.Minutes, Is.EqualTo(59));
            Assert.That(result.TimeOfDay.Seconds, Is.EqualTo(59));
            Assert.That(result.TimeOfDay.Milliseconds, Is.EqualTo(999));
            Assert.That(result.TimeOfDay.Ticks % TimeSpan.TicksPerMillisecond, Is.EqualTo(TimeSpan.TicksPerMillisecond - 1));
        }

        [TestCaseSource(nameof(SampleDateTimes))]
        public void StartOfDay(DateTime datetime)
        {
            var result = datetime.StartOfDay();

            Assert.That(result.Kind, Is.EqualTo(datetime.Kind));
            Assert.That(result.Date, Is.EqualTo(datetime.Date));
            Assert.That(result.TimeOfDay.Ticks, Is.Zero);
        }

        [TestCaseSource(nameof(SampleDateTimes))]
        public void EndOfDay(DateTime datetime)
        {
            var result = datetime.EndOfDay();

            Assert.That(result.Kind, Is.EqualTo(datetime.Kind));
            Assert.That(result.Date, Is.EqualTo(datetime.Date));
            Assert.That(result.TimeOfDay.Ticks, Is.EqualTo(TimeSpan.TicksPerDay - 1));
        }

        [Test]
        public void StartOfWeek([Values] DayOfWeek firstDayOfWeek)
        {
            var datetime = DateTime.UtcNow;
            var result = datetime.StartOfWeek(firstDayOfWeek);

            Assert.That(result.Kind, Is.EqualTo(datetime.Kind));
            Assert.That(result.TimeOfDay.Ticks, Is.Zero);
            Assert.That(result.DayOfWeek, Is.EqualTo(firstDayOfWeek));
            Assert.That((result - datetime).Days, Is.GreaterThan(-7).And.LessThan(7));
        }

        [Test]
        public void EndOfWeek([Values] DayOfWeek firstDayOfWeek)
        {
            var lastDayOfWeek = (DayOfWeek)(((int)firstDayOfWeek + 6) % 7);

            var datetime = DateTime.UtcNow;
            var result = datetime.EndOfWeek(firstDayOfWeek);

            Assert.That(result.Kind, Is.EqualTo(datetime.Kind));
            Assert.That(result.TimeOfDay.Ticks, Is.EqualTo(TimeSpan.TicksPerDay - 1));
            Assert.That(result.DayOfWeek, Is.EqualTo(lastDayOfWeek));
            Assert.That((result - datetime).Days, Is.GreaterThan(-7).And.LessThan(7));
        }

        [TestCaseSource(nameof(SampleDateTimes))]
        public void StartOfMonth(DateTime datetime)
        {
            var result = datetime.StartOfMonth();

            Assert.That(result.Kind, Is.EqualTo(datetime.Kind));
            Assert.That(result.TimeOfDay.Ticks, Is.Zero);
            Assert.That(result.Year, Is.EqualTo(datetime.Year));
            Assert.That(result.Month, Is.EqualTo(datetime.Month));
            Assert.That(result.Day, Is.EqualTo(1));
        }

        [TestCaseSource(nameof(SampleDateTimes))]
        public void EndOfMonth(DateTime datetime)
        {
            var result = datetime.EndOfMonth();

            Assert.That(result.Kind, Is.EqualTo(datetime.Kind));
            Assert.That(result.TimeOfDay.Ticks, Is.EqualTo(TimeSpan.TicksPerDay - 1));
            Assert.That(result.Year, Is.EqualTo(datetime.Year));
            Assert.That(result.Month, Is.EqualTo(datetime.Month));
            Assert.That(result.Day, Is.EqualTo(DateTime.DaysInMonth(datetime.Year, datetime.Month)));
        }

        [TestCaseSource(nameof(SampleDateTimes))]
        public void StartOfYear(DateTime datetime)
        {
            var result = datetime.StartOfYear();

            Assert.That(result.Kind, Is.EqualTo(datetime.Kind));
            Assert.That(result.TimeOfDay.Ticks, Is.Zero);
            Assert.That(result.Year, Is.EqualTo(datetime.Year));
            Assert.That(result.Month, Is.EqualTo(1));
            Assert.That(result.Day, Is.EqualTo(1));
        }

        [TestCaseSource(nameof(SampleDateTimes))]
        public void EndOfYear(DateTime datetime)
        {
            var result = datetime.EndOfYear();

            Assert.That(result.Kind, Is.EqualTo(datetime.Kind));
            Assert.That(result.TimeOfDay.Ticks, Is.EqualTo(TimeSpan.TicksPerDay - 1));
            Assert.That(result.Year, Is.EqualTo(datetime.Year));
            Assert.That(result.Month, Is.EqualTo(12));
            Assert.That(result.Day, Is.EqualTo(31));
        }

        [TestCase(2019, 01, 06, ExpectedResult = WeekOfMonth.First)]
        [TestCase(2019, 01, 07, ExpectedResult = WeekOfMonth.Second)]
        [TestCase(2019, 01, 19, ExpectedResult = WeekOfMonth.Third)]
        [TestCase(2019, 01, 22, ExpectedResult = WeekOfMonth.Fourth)]
        [TestCase(2019, 01, 28, ExpectedResult = WeekOfMonth.Last)]
        public WeekOfMonth WeekOfTheMonth(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);

            return date.WeekOfMonth();
        }

        [TestCase(2020, 08, 01, ExpectedResult = WeekOfMonth.First)]
        [TestCase(2020, 08, 03, ExpectedResult = WeekOfMonth.First)]
        [TestCase(2020, 08, 07, ExpectedResult = WeekOfMonth.First)]
        [TestCase(2020, 08, 08, ExpectedResult = WeekOfMonth.Second)]
        [TestCase(2020, 08, 10, ExpectedResult = WeekOfMonth.Second)]
        [TestCase(2020, 08, 14, ExpectedResult = WeekOfMonth.Second)]
        [TestCase(2020, 08, 16, ExpectedResult = WeekOfMonth.Third)]
        [TestCase(2020, 08, 17, ExpectedResult = WeekOfMonth.Third)]
        [TestCase(2020, 08, 19, ExpectedResult = WeekOfMonth.Third)]
        [TestCase(2020, 08, 23, ExpectedResult = WeekOfMonth.Fourth)]
        [TestCase(2020, 08, 24, ExpectedResult = WeekOfMonth.Fourth)]
        [TestCase(2020, 08, 30, ExpectedResult = WeekOfMonth.Last)]
        [TestCase(2020, 08, 31, ExpectedResult = WeekOfMonth.Last)]
        public WeekOfMonth DayOfWeekInstance(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);

            return date.DayOfWeekInstance();
        }

        [TestCaseSource(nameof(SampleDateTimes))]
        public void DaysInMonth(DateTime datetime)
        {
            var result = datetime.DaysInMonth();

            Assert.That(result, Is.EqualTo(DateTime.DaysInMonth(datetime.Year, datetime.Month)));
        }

        [TestCase(2096, 5, 5, ExpectedResult = 366)]
        [TestCase(2100, 4, 4, ExpectedResult = 365)]
        [TestCase(2104, 6, 6, ExpectedResult = 366)]
        public int DaysInYear(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);

            return date.DaysInYear();
        }

        [TestCase(2004, 4, 4, ExpectedResult = 53)]
        [TestCase(2005, 5, 5, ExpectedResult = 52)]
        [TestCase(2006, 6, 6, ExpectedResult = 52)]
        [TestCase(2007, 7, 7, ExpectedResult = 52)]
        [TestCase(2008, 8, 8, ExpectedResult = 52)]
        [TestCase(2009, 9, 9, ExpectedResult = 53)]
        public int Iso8601_Weeks_In_Year(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);

            return date.WeeksInYear();
        }

        [TestCase(2005, 01, 01, ExpectedResult = "2004-W53-6")]
        [TestCase(2005, 01, 02, ExpectedResult = "2004-W53-7")]
        [TestCase(2005, 12, 31, ExpectedResult = "2005-W52-6")]
        [TestCase(2006, 01, 01, ExpectedResult = "2005-W52-7")]
        [TestCase(2006, 01, 02, ExpectedResult = "2006-W01-1")]
        [TestCase(2006, 12, 31, ExpectedResult = "2006-W52-7")]
        [TestCase(2007, 01, 01, ExpectedResult = "2007-W01-1")]
        [TestCase(2007, 12, 30, ExpectedResult = "2007-W52-7")]
        [TestCase(2007, 12, 31, ExpectedResult = "2008-W01-1")]
        [TestCase(2008, 01, 01, ExpectedResult = "2008-W01-2")]
        [TestCase(2008, 12, 28, ExpectedResult = "2008-W52-7")]
        [TestCase(2008, 12, 29, ExpectedResult = "2009-W01-1")]
        [TestCase(2008, 12, 30, ExpectedResult = "2009-W01-2")]
        [TestCase(2008, 12, 31, ExpectedResult = "2009-W01-3")]
        [TestCase(2009, 01, 01, ExpectedResult = "2009-W01-4")]
        [TestCase(2009, 12, 31, ExpectedResult = "2009-W53-4")]
        [TestCase(2010, 01, 01, ExpectedResult = "2009-W53-5")]
        [TestCase(2010, 01, 02, ExpectedResult = "2009-W53-6")]
        [TestCase(2010, 01, 03, ExpectedResult = "2009-W53-7")]
        public string FormatIso8601(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);

            return date.FormatIso8601();
        }
    }
}