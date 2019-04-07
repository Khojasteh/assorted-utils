// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using Assorted.Utils.Dates;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Assorted.Utils.Serialization.Tests
{
    [TestFixture]
    [SetCulture("fa")]
    [SetUICulture("fa")]
    [TestOf(typeof(ConvertUtils))]
    public class ConvertUtilsTests
    {
        [TestCase("any", ExpectedResult = DaysOfTheWeek.Any)]
        [TestCase("0", ExpectedResult = DaysOfTheWeek.None)]
        [TestCase("TUESDAY", ExpectedResult = DaysOfTheWeek.Tuesday)]
        [TestCase("4", ExpectedResult = DaysOfTheWeek.Wednesday)]
        [TestCase("weekend", ExpectedResult = DaysOfTheWeek.Weekend)]
        [TestCase("31", ExpectedResult = DaysOfTheWeek.Weekday)]
        [TestCase("Thursday, Friday", ExpectedResult = DaysOfTheWeek.Thursday | DaysOfTheWeek.Friday)]
        [TestCase("BAD_DAY", ExpectedResult = null)]
        public DaysOfTheWeek? Standard_String_To_Enum(string s)
        {
            return ConvertUtils.StrToEnum<DaysOfTheWeek>(s);
        }

        [TestCase("FALSE", ExpectedResult = false)]
        [TestCase("false", ExpectedResult = false)]
        [TestCase("0", ExpectedResult = false)]
        [TestCase("TRUE", ExpectedResult = true)]
        [TestCase("true", ExpectedResult = true)]
        [TestCase("1", ExpectedResult = true)]
        [TestCase("Yes", ExpectedResult = null)]
        [TestCase("F", ExpectedResult = null)]
        [TestCase("2", ExpectedResult = null)]
        public bool? Standard_String_To_Boolean(string s)
        {
            return ConvertUtils.StrToBool(s);
        }

        [TestCase("0", ExpectedResult = 0)]
        [TestCase("127", ExpectedResult = sbyte.MaxValue)]
        [TestCase("128", ExpectedResult = null)]
        [TestCase("+0", ExpectedResult = 0)]
        [TestCase("+127", ExpectedResult = sbyte.MaxValue)]
        [TestCase("+128", ExpectedResult = null)]
        [TestCase("-0", ExpectedResult = 0)]
        [TestCase("-128", ExpectedResult = sbyte.MinValue)]
        [TestCase("-129", ExpectedResult = null)]
        [TestCase("0xFF", ExpectedResult = null)]
        [TestCase("0.0", ExpectedResult = null)]
        [TestCase("0 0", ExpectedResult = null)]
        [TestCase("Invalid", ExpectedResult = null)]
        public sbyte? Standard_String_To_Signed_8bit_Integer(string s)
        {
            return ConvertUtils.StrToInt8(s);
        }

        [TestCase("0", ExpectedResult = 0u)]
        [TestCase("255", ExpectedResult = byte.MaxValue)]
        [TestCase("256", ExpectedResult = null)]
        [TestCase("+0", ExpectedResult = 0u)]
        [TestCase("+255", ExpectedResult = Byte.MaxValue)]
        [TestCase("+256", ExpectedResult = null)]
        [TestCase("-0", ExpectedResult = 0u)]
        [TestCase("-128", ExpectedResult = null)]
        [TestCase("0xFF", ExpectedResult = null)]
        [TestCase("0.0", ExpectedResult = null)]
        [TestCase("0 0", ExpectedResult = null)]
        [TestCase("Invalid", ExpectedResult = null)]
        public byte? Standard_String_To_Unsigned_8bit_Integer(string s)
        {
            return ConvertUtils.StrToUInt8(s);
        }

        [TestCase("0", ExpectedResult = 0)]
        [TestCase("32767", ExpectedResult = short.MaxValue)]
        [TestCase("32768", ExpectedResult = null)]
        [TestCase("+0", ExpectedResult = 0)]
        [TestCase("+32767", ExpectedResult = short.MaxValue)]
        [TestCase("+32768", ExpectedResult = null)]
        [TestCase("-0", ExpectedResult = 0)]
        [TestCase("-32768", ExpectedResult = short.MinValue)]
        [TestCase("-32769", ExpectedResult = null)]
        [TestCase("0xFFFF", ExpectedResult = null)]
        [TestCase("0.0", ExpectedResult = null)]
        [TestCase("0 0", ExpectedResult = null)]
        [TestCase("Invalid", ExpectedResult = null)]
        public short? Standard_String_To_Signed_16bit_Integer(string s)
        {
            return ConvertUtils.StrToInt16(s);
        }

        [TestCase("0", ExpectedResult = 0u)]
        [TestCase("65535", ExpectedResult = ushort.MaxValue)]
        [TestCase("65536", ExpectedResult = null)]
        [TestCase("+0", ExpectedResult = 0u)]
        [TestCase("+65535", ExpectedResult = ushort.MaxValue)]
        [TestCase("+65536", ExpectedResult = null)]
        [TestCase("-0", ExpectedResult = 0u)]
        [TestCase("-32768", ExpectedResult = null)]
        [TestCase("0xFFFF", ExpectedResult = null)]
        [TestCase("0.0", ExpectedResult = null)]
        [TestCase("0 0", ExpectedResult = null)]
        [TestCase("Invalid", ExpectedResult = null)]
        public ushort? Standard_String_To_Unsigned_16bit_Integer(string s)
        {
            return ConvertUtils.StrToUInt16(s);
        }

        [TestCase("0", ExpectedResult = 0)]
        [TestCase("2147483647", ExpectedResult = int.MaxValue‬‬)]
        [TestCase("‭2147483648‬", ExpectedResult = null)]
        [TestCase("+0", ExpectedResult = 0)]
        [TestCase("+2147483647", ExpectedResult = int.MaxValue‬‬)]
        [TestCase("+2147483648", ExpectedResult = null)]
        [TestCase("-0", ExpectedResult = 0)]
        [TestCase("-2147483648", ExpectedResult = int.MinValue)]
        [TestCase("-2147483649", ExpectedResult = null)]
        [TestCase("0xFFFFFFFF", ExpectedResult = null)]
        [TestCase("0.0", ExpectedResult = null)]
        [TestCase("0 0", ExpectedResult = null)]
        [TestCase("Invalid", ExpectedResult = null)]
        public int? Standard_String_To_Signed_32bit_Integer(string s)
        {
            return ConvertUtils.StrToInt32(s);
        }

        [TestCase("0", ExpectedResult = 0u)]
        [TestCase("4294967295", ExpectedResult = uint.MaxValue)]
        [TestCase("‭4294967295‬", ExpectedResult = null)]
        [TestCase("+0", ExpectedResult = 0u)]
        [TestCase("+4294967295", ExpectedResult = uint.MaxValue)]
        [TestCase("+‭4294967296‬", ExpectedResult = null)]
        [TestCase("-0", ExpectedResult = 0u)]
        [TestCase("-2147483648", ExpectedResult = null)]
        [TestCase("0xFFFFFFFF", ExpectedResult = null)]
        [TestCase("0.0", ExpectedResult = null)]
        [TestCase("0 0", ExpectedResult = null)]
        [TestCase("Invalid", ExpectedResult = null)]
        public uint? Standard_String_To_Unsigned_32bit_Integer(string s)
        {
            return ConvertUtils.StrToUInt32(s);
        }

        [TestCase("0", ExpectedResult = 0L)]
        [TestCase("9223372036854775807", ExpectedResult = long.MaxValue‬‬)]
        [TestCase("‭9223372036854775808‬", ExpectedResult = null)]
        [TestCase("+0", ExpectedResult = 0L)]
        [TestCase("+9223372036854775807", ExpectedResult = long.MaxValue‬‬)]
        [TestCase("+9223372036854775808", ExpectedResult = null)]
        [TestCase("-0", ExpectedResult = 0L)]
        [TestCase("-9223372036854775808", ExpectedResult = long.MinValue)]
        [TestCase("-9223372036854775809", ExpectedResult = null)]
        [TestCase("0xFFFFFFFFFFFFFFFF", ExpectedResult = null)]
        [TestCase("0.0", ExpectedResult = null)]
        [TestCase("0 0", ExpectedResult = null)]
        [TestCase("Invalid", ExpectedResult = null)]
        public long? Standard_String_To_Signed_64bit_Integer(string s)
        {
            return ConvertUtils.StrToInt64(s);
        }

        [TestCase("0", ExpectedResult = 0ul)]
        [TestCase("18446744073709551615", ExpectedResult = ulong.MaxValue)]
        [TestCase("‭18446744073709551616‬", ExpectedResult = null)]
        [TestCase("+0", ExpectedResult = 0ul)]
        [TestCase("+18446744073709551615", ExpectedResult = ulong.MaxValue)]
        [TestCase("+‭18446744073709551616‬", ExpectedResult = null)]
        [TestCase("-0", ExpectedResult = 0ul)]
        [TestCase("-2147483648", ExpectedResult = null)]
        [TestCase("0xFFFFFFFFFFFFFFFF", ExpectedResult = null)]
        [TestCase("0.0", ExpectedResult = null)]
        [TestCase("0 0", ExpectedResult = null)]
        [TestCase("Invalid", ExpectedResult = null)]
        public ulong? Standard_String_To_Unsigned_64bit_Integer(string s)
        {
            return ConvertUtils.StrToUInt64(s);
        }

        [TestCase("12345.6789", ExpectedResult = 12345.6789f)]
        [TestCase("+1.401298E-45", ExpectedResult = float.Epsilon)]
        [TestCase("-1.401298E-45", ExpectedResult = -float.Epsilon)]
        [TestCase("+3.40282347E+38", ExpectedResult = float.MaxValue)]
        [TestCase("-3.40282347E+38", ExpectedResult = float.MinValue)]
        [TestCase("Infinity", ExpectedResult = float.PositiveInfinity)]
        [TestCase("-Infinity", ExpectedResult = float.NegativeInfinity)]
        [TestCase("NaN", ExpectedResult = float.NaN)]
        [TestCase("1E-50", ExpectedResult = 0.0f)]
        [TestCase("1E+50", ExpectedResult = null)]
        [TestCase("0 0", ExpectedResult = null)]
        [TestCase("Invalid", ExpectedResult = null)]
        public float? Standard_String_To_Single_Precision_Float(string s)
        {
            return ConvertUtils.StrToSingle(s);
        }

        [TestCase("12345.6789", ExpectedResult = 12345.6789)]
        [TestCase("4.94065645841247E-324", ExpectedResult = double.Epsilon)]
        [TestCase("-4.94065645841247E-324", ExpectedResult = -double.Epsilon)]
        [TestCase("+1.7976931348623157E+308", ExpectedResult = double.MaxValue)]
        [TestCase("-1.7976931348623157E+308", ExpectedResult = double.MinValue)]
        [TestCase("Infinity", ExpectedResult = double.PositiveInfinity)]
        [TestCase("-Infinity", ExpectedResult = double.NegativeInfinity)]
        [TestCase("NaN", ExpectedResult = double.NaN)]
        [TestCase("1E-330", ExpectedResult = 0.0)]
        [TestCase("1E+310", ExpectedResult = null)]
        [TestCase("0 0", ExpectedResult = null)]
        [TestCase("Invalid", ExpectedResult = null)]
        public double? Standard_String_To_Double_Precision_Float(string s)
        {
            return ConvertUtils.StrToDouble(s);
        }

        static IEnumerable<TestCaseData> TestCases_For_Standard_String_To_Decimal()
        {
            yield return new TestCaseData("+79228162514264337593543950335")
                .Returns(decimal.MaxValue);
            yield return new TestCaseData("-79228162514264337593543950335")
                .Returns(decimal.MinValue);
            yield return new TestCaseData("0.1234567890123456789012345678")
                .Returns(0.1234567890123456789012345678m);
            yield return new TestCaseData("+1E-28")
                .Returns(1.0E-28m);
            yield return new TestCaseData("-1E-28")
                .Returns(-1.0E-28m);
            yield return new TestCaseData("+7.9228E+28")
                .Returns(7.9228E+28m);
            yield return new TestCaseData("-7.9228E+28")
                .Returns(-7.9228E+28m);
            yield return new TestCaseData("Infinity")
                .Returns(null);
            yield return new TestCaseData("NaN")
                .Returns(null);
            yield return new TestCaseData("1E-30")
                .Returns(decimal.Zero);
            yield return new TestCaseData("1E+30")
                .Returns(null);
            yield return new TestCaseData("0 0")
                .Returns(null);
            yield return new TestCaseData("Invalid")
                .Returns(null);
        }

        [TestCaseSource(nameof(TestCases_For_Standard_String_To_Decimal))]
        public decimal? Standard_String_To_Decimal(string s)
        {
            return ConvertUtils.StrToDecimal(s);
        }

        static IEnumerable<TestCaseData> TestCases_For_Standard_String_To_Date()
        {
            yield return new TestCaseData("0001-01-01")
                .Returns(DateTime.MinValue.Date);
            yield return new TestCaseData("9999-12-31")
                .Returns(DateTime.MaxValue.Date);
            yield return new TestCaseData("2020-01-01")
                .Returns(new DateTime(2020, 01, 01));
            yield return new TestCaseData("2020-1-1")
                .Returns(null);
            yield return new TestCaseData("20-01-01")
                .Returns(null);
            yield return new TestCaseData("2020/01/01")
                .Returns(null);
            yield return new TestCaseData("01-01-2020")
                .Returns(null);
            yield return new TestCaseData("2020-13-01")
                .Returns(null);
            yield return new TestCaseData("2020-01-32")
                .Returns(null);
            yield return new TestCaseData("0000-01-01")
                .Returns(null);
            yield return new TestCaseData("10000-01-01")
                .Returns(null);
        }

        [TestCaseSource(nameof(TestCases_For_Standard_String_To_Date))]
        public DateTime? Standard_String_To_Date(string s)
        {
            return ConvertUtils.StrToDate(s);
        }

        static IEnumerable<TestCaseData> TestCases_For_Standard_String_To_Time()
        {
            yield return new TestCaseData("00:00:00")
                .Returns(new DateTime(0001, 01, 01, 00, 00, 00));
            yield return new TestCaseData("23:59:59")
                .Returns(new DateTime(0001, 01, 01, 23, 59, 59));
            yield return new TestCaseData("23:59:59.123")
                .Returns(new DateTime(0001, 01, 01, 23, 59, 59, 123));
            yield return new TestCaseData("0:0:0")
                .Returns(null);
            yield return new TestCaseData("00:00")
                .Returns(null);
            yield return new TestCaseData("24:00:00")
                .Returns(null);
            yield return new TestCaseData("18:60:00")
                .Returns(null);
            yield return new TestCaseData("18:30:60")
                .Returns(null);
            yield return new TestCaseData("18")
                .Returns(null);
            yield return new TestCaseData("Invalid").Returns(null);
        }

        [TestCaseSource(nameof(TestCases_For_Standard_String_To_Time))]
        public DateTime? Standard_String_To_Time(string s)
        {
            return ConvertUtils.StrToTime(s);
        }

        static IEnumerable<TestCaseData> TestCases_For_Standard_String_To_DateTime()
        {
            yield return new TestCaseData("0001-01-01T00:00:00.000000Z")
                .Returns(new DateTime(0001, 01, 01, 00, 00, 00, DateTimeKind.Utc));
            yield return new TestCaseData("9999-12-31T23:59:59Z")
                .Returns(new DateTime(9999, 12, 31, 23, 59, 59, DateTimeKind.Utc));
            yield return new TestCaseData("2020-01-01T00:00:00-02:30")
                .Returns(new DateTime(2020, 01, 01, 02, 30, 00, DateTimeKind.Utc));
            yield return new TestCaseData("2020-01-01T00:00:00+02:30")
                .Returns(new DateTime(2019, 12, 31, 21, 30, 00, DateTimeKind.Utc));
            yield return new TestCaseData("2020-01-01 00:00:00")
                .Returns(new DateTime(2020, 01, 01, 00, 00, 00, DateTimeKind.Unspecified));
            yield return new TestCaseData("Wed, 01 Jan 2020 23:59:59 GMT")
                .Returns(new DateTime(2020, 01, 01, 23, 59, 59, DateTimeKind.Utc));
            yield return new TestCaseData("2020-12-31")
                .Returns(null);
            yield return new TestCaseData("23:59:59")
                .Returns(null);
            yield return new TestCaseData("2020-12-31T23:59:59 GMT")
                .Returns(null);
        }

        [TestCaseSource(nameof(TestCases_For_Standard_String_To_DateTime))]
        public DateTime? Standard_String_To_DateTime(string s)
        {
            return ConvertUtils.StrToDateTime(s);
        }

        static IEnumerable<TestCaseData> TestCases_For_Standard_String_To_DateTimeOffset()
        {
            yield return new TestCaseData("0001-01-01T00:00:00.000000Z")
                .Returns(new DateTimeOffset(0001, 01, 01, 00, 00, 00, TimeSpan.Zero));
            yield return new TestCaseData("9999-12-31T23:59:59Z")
                .Returns(new DateTimeOffset(9999, 12, 31, 23, 59, 59, TimeSpan.Zero));
            yield return new TestCaseData("2020-01-01T00:00:00-02:30")
                .Returns(new DateTimeOffset(2020, 01, 01, 00, 00, 00, TimeSpan.FromHours(-2.5)));
            yield return new TestCaseData("2020-01-01T00:00:00+02:30")
                .Returns(new DateTimeOffset(2020, 01, 01, 00, 00, 00, TimeSpan.FromHours(+2.5)));
            yield return new TestCaseData("2020-01-01 00:00:00")
                .Returns(new DateTimeOffset(2020, 01, 01, 00, 00, 00, TimeZoneInfo.Local.GetUtcOffset(new DateTime(2020, 01, 01))));
            yield return new TestCaseData("Wed, 01 Jan 2020 23:59:59 GMT")
                .Returns(new DateTimeOffset(2020, 01, 01, 23, 59, 59, TimeSpan.Zero));
            yield return new TestCaseData("2020-12-31")
                .Returns(null);
            yield return new TestCaseData("23:59:59")
                .Returns(null);
            yield return new TestCaseData("2020-12-31T23:59:59 GMT")
                .Returns(null);
        }

        [TestCaseSource(nameof(TestCases_For_Standard_String_To_DateTimeOffset))]
        public DateTimeOffset? Standard_String_To_DateTimeOffset(string s)
        {
            return ConvertUtils.StrToDateTimeOffset(s);
        }
    }
}