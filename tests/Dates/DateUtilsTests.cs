using NUnit.Framework;
using System;

namespace Assorted.Utils.Dates.Tests
{
    [TestFixture]
    [TestOf(typeof(DateUtils))]
    public class DateUtilsTests
    {
        [TestCase(DayOfWeek.Monday, 0, ExpectedResult = DayOfWeek.Monday)]
        [TestCase(DayOfWeek.Monday, -1, ExpectedResult = DayOfWeek.Sunday)]
        [TestCase(DayOfWeek.Monday, -8, ExpectedResult = DayOfWeek.Sunday)]
        [TestCase(DayOfWeek.Monday, 1, ExpectedResult = DayOfWeek.Tuesday)]
        [TestCase(DayOfWeek.Monday, 8, ExpectedResult = DayOfWeek.Tuesday)]
        [TestCase(DayOfWeek.Sunday, 0, ExpectedResult = DayOfWeek.Sunday)]
        [TestCase(DayOfWeek.Sunday, -1, ExpectedResult = DayOfWeek.Saturday)]
        [TestCase(DayOfWeek.Sunday, -8, ExpectedResult = DayOfWeek.Saturday)]
        [TestCase(DayOfWeek.Sunday, 1, ExpectedResult = DayOfWeek.Monday)]
        [TestCase(DayOfWeek.Sunday, 8, ExpectedResult = DayOfWeek.Monday)]
        public static DayOfWeek DayOfWeek_For_Days_After_StartOfWeek(DayOfWeek firstDayOfWeek, int days)
        {
            return DateUtils.DaysFromStartOfTheWeekToDayOfWeek(days, firstDayOfWeek);
        }

        [TestCase(WeekOfMonth.First, DayOfWeek.Thursday, 13, 2018)]
        [TestCase(WeekOfMonth.Second, DayOfWeek.Thursday, 0, 2018)]
        [TestCase(WeekOfMonth.First, DayOfWeek.Thursday, -1, 2018)]
        [TestCase(WeekOfMonth.Second, DayOfWeek.Thursday, 11, 0)]
        [TestCase(WeekOfMonth.Last, DayOfWeek.Thursday, 11, -2018)]
        [TestCase(WeekOfMonth.First, DayOfWeek.Friday, 12, 10000)]
        public void Date_For_Nth_DayOfWeek_Occurrence_In_MonthOfYear_InvalidParam(WeekOfMonth weekOfMonth, DayOfWeek dayOfWeek, int month, int year)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => DateUtils.DateFor(weekOfMonth, dayOfWeek, month, year));
        }

        [TestCase(WeekOfMonth.First, DayOfWeek.Thursday, MonthOfYear.November, 2018, ExpectedResult = "2018-11-01")]
        [TestCase(WeekOfMonth.Second, DayOfWeek.Thursday, MonthOfYear.November, 2018, ExpectedResult = "2018-11-08")]
        [TestCase(WeekOfMonth.Third, DayOfWeek.Thursday, MonthOfYear.November, 2018, ExpectedResult = "2018-11-15")]
        [TestCase(WeekOfMonth.Fourth, DayOfWeek.Thursday, MonthOfYear.November, 2018, ExpectedResult = "2018-11-22")]
        [TestCase(WeekOfMonth.Last, DayOfWeek.Thursday, MonthOfYear.November, 2018, ExpectedResult = "2018-11-29")]
        [TestCase(WeekOfMonth.First, DayOfWeek.Friday, MonthOfYear.December, 2018, ExpectedResult = "2018-12-07")]
        [TestCase(WeekOfMonth.Second, DayOfWeek.Friday, MonthOfYear.December, 2018, ExpectedResult = "2018-12-14")]
        [TestCase(WeekOfMonth.Third, DayOfWeek.Friday, MonthOfYear.December, 2018, ExpectedResult = "2018-12-21")]
        [TestCase(WeekOfMonth.Fourth, DayOfWeek.Friday, MonthOfYear.December, 2018, ExpectedResult = "2018-12-28")]
        [TestCase(WeekOfMonth.Last, DayOfWeek.Friday, MonthOfYear.December, 2018, ExpectedResult = "2018-12-28")]
        [TestCase(WeekOfMonth.First, DayOfWeek.Monday, MonthOfYear.September, 2019, ExpectedResult = "2019-09-02")]
        [TestCase(WeekOfMonth.Last, DayOfWeek.Monday, MonthOfYear.September, 2019, ExpectedResult = "2019-09-30")]
        public string Date_For_Nth_DayOfWeek_Occurrence_In_MonthOfYear(WeekOfMonth weekOfMonth, DayOfWeek dayOfWeek, MonthOfYear month, int year)
        {
            return DateUtils.DateFor(weekOfMonth, dayOfWeek, month, year).ToString("yyyy-MM-dd");
        }

        [TestCase(-2004, 53, DayOfWeek.Saturday)]
        [TestCase(0, 53, DayOfWeek.Sunday)]
        [TestCase(10000, 52, DayOfWeek.Saturday)]
        [TestCase(2005, -52, DayOfWeek.Sunday)]
        [TestCase(2006, 0, DayOfWeek.Monday)]
        [TestCase(2006, 54, DayOfWeek.Sunday)]
        public void Date_For_Iso8601_InvalidParam(int year, int week, DayOfWeek dayOfWeek)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => DateUtils.DateForIso8601(year, week, dayOfWeek));
        }

        [TestCase(2004, 53, DayOfWeek.Saturday, ExpectedResult = "2005-01-01")]
        [TestCase(2004, 53, DayOfWeek.Sunday, ExpectedResult = "2005-01-02")]
        [TestCase(2005, 52, DayOfWeek.Saturday, ExpectedResult = "2005-12-31")]
        [TestCase(2005, 52, DayOfWeek.Sunday, ExpectedResult = "2006-01-01")]
        [TestCase(2006, 01, DayOfWeek.Monday, ExpectedResult = "2006-01-02")]
        [TestCase(2006, 52, DayOfWeek.Sunday, ExpectedResult = "2006-12-31")]
        [TestCase(2007, 01, DayOfWeek.Monday, ExpectedResult = "2007-01-01")]
        [TestCase(2007, 52, DayOfWeek.Sunday, ExpectedResult = "2007-12-30")]
        [TestCase(2008, 01, DayOfWeek.Monday, ExpectedResult = "2007-12-31")]
        [TestCase(2008, 01, DayOfWeek.Tuesday, ExpectedResult = "2008-01-01")]
        [TestCase(2008, 52, DayOfWeek.Sunday, ExpectedResult = "2008-12-28")]
        [TestCase(2009, 01, DayOfWeek.Monday, ExpectedResult = "2008-12-29")]
        [TestCase(2009, 01, DayOfWeek.Tuesday, ExpectedResult = "2008-12-30")]
        [TestCase(2009, 01, DayOfWeek.Wednesday, ExpectedResult = "2008-12-31")]
        [TestCase(2009, 01, DayOfWeek.Thursday, ExpectedResult = "2009-01-01")]
        [TestCase(2009, 53, DayOfWeek.Thursday, ExpectedResult = "2009-12-31")]
        [TestCase(2009, 53, DayOfWeek.Friday, ExpectedResult = "2010-01-01")]
        [TestCase(2009, 53, DayOfWeek.Saturday, ExpectedResult = "2010-01-02")]
        [TestCase(2009, 53, DayOfWeek.Sunday, ExpectedResult = "2010-01-03")]
        public string Date_For_Iso8601(int year, int week, DayOfWeek dayOfWeek)
        {
            return DateUtils.DateForIso8601(year, week, dayOfWeek).ToString("yyyy-MM-dd");
        }

        [TestCase("2004-W53-6", ExpectedResult = "2005-01-01")]
        [TestCase("2004-W53-7", ExpectedResult = "2005-01-02")]
        [TestCase("2005-W52-6", ExpectedResult = "2005-12-31")]
        [TestCase("2005-W52-7", ExpectedResult = "2006-01-01")]
        [TestCase("2006-W01-1", ExpectedResult = "2006-01-02")]
        [TestCase("2006-W52-7", ExpectedResult = "2006-12-31")]
        [TestCase("2007-W01-1", ExpectedResult = "2007-01-01")]
        [TestCase("2007-W52-7", ExpectedResult = "2007-12-30")]
        [TestCase("2008-W01-1", ExpectedResult = "2007-12-31")]
        [TestCase("2008-W01-2", ExpectedResult = "2008-01-01")]
        [TestCase("2008-W52-7", ExpectedResult = "2008-12-28")]
        [TestCase("2009-W01-1", ExpectedResult = "2008-12-29")]
        [TestCase("2009-W01-2", ExpectedResult = "2008-12-30")]
        [TestCase("2009-W01-3", ExpectedResult = "2008-12-31")]
        [TestCase("2009-W01-4", ExpectedResult = "2009-01-01")]
        [TestCase("2009-W53-4", ExpectedResult = "2009-12-31")]
        [TestCase("2009-W53-5", ExpectedResult = "2010-01-01")]
        [TestCase("2009-W53-6", ExpectedResult = "2010-01-02")]
        [TestCase("2009-W53-7", ExpectedResult = "2010-01-03")]
        public string Parse_Iso8601(string iso)
        {
            return DateUtils.ParseIso8601(iso).ToString("yyyy-MM-dd");
        }

        [TestCase(2004, ExpectedResult = 53)]
        [TestCase(2005, ExpectedResult = 52)]
        [TestCase(2006, ExpectedResult = 52)]
        [TestCase(2007, ExpectedResult = 52)]
        [TestCase(2008, ExpectedResult = 52)]
        [TestCase(2009, ExpectedResult = 53)]
        public int Iso8601_Weeks_In_Year(int year)
        {
            return DateUtils.WeeksInYear(year);
        }
    }
}