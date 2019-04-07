// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using Assorted.Utils.Dates;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Assorted.Utils.Serialization.Tests
{
    [TestFixture]
    [SetCulture("fa")]
    [SetUICulture("fa")]
    [TestOf(typeof(ConvertExtensions))]
    public class ConvertExtensionsTests
    {
        [TestCase(DaysOfTheWeek.Any, ExpectedResult = "127")]
        [TestCase(DaysOfTheWeek.Wednesday, ExpectedResult = "4")]
        [TestCase(DaysOfTheWeek.Weekend, ExpectedResult = "96")]
        public string Enum_To_Standard_String(DaysOfTheWeek value)
        {
            return value.ToStandardString();
        }

        [TestCase(false, ExpectedResult = "false")]
        [TestCase(true, ExpectedResult = "true")]
        public string Boolean_To_Standard_String(bool value)
        {
            return value.ToStandardString();
        }

        [TestCase(sbyte.MinValue, ExpectedResult = "-128")]
        [TestCase(sbyte.MaxValue, ExpectedResult = "127")]
        public string Signed_8bit_Integer_To_Standard_String(sbyte value)
        {
            return value.ToStandardString();
        }

        [TestCase(byte.MinValue, ExpectedResult = "0")]
        [TestCase(byte.MaxValue, ExpectedResult = "255")]
        public string Unsigned_8bit_Integer_To_Standard_String(byte value)
        {
            return value.ToStandardString();
        }

        [TestCase(short.MinValue, ExpectedResult = "-32768")]
        [TestCase(short.MaxValue, ExpectedResult = "32767")]
        public string Signed_16bit_Integer_To_Standard_String(short value)
        {
            return value.ToStandardString();
        }

        [TestCase(ushort.MinValue, ExpectedResult = "0")]
        [TestCase(ushort.MaxValue, ExpectedResult = "65535")]
        public string Unsigned_16bit_Integer_To_Standard_String(ushort value)
        {
            return value.ToStandardString();
        }

        [TestCase(int.MinValue, ExpectedResult = "-2147483648")]
        [TestCase(int.MaxValue, ExpectedResult = "2147483647")]
        public string Signed_32bit_Integer_To_Standard_String(int value)
        {
            return value.ToStandardString();
        }

        [TestCase(uint.MinValue, ExpectedResult = "0")]
        [TestCase(uint.MaxValue, ExpectedResult = "4294967295")]
        public string Unsigned_32bit_Integer_To_Standard_String(uint value)
        {
            return value.ToStandardString();
        }

        [TestCase(long.MinValue, ExpectedResult = "-9223372036854775808")]
        [TestCase(long.MaxValue, ExpectedResult = "9223372036854775807")]
        public string Signed_64bit_Integer_To_Standard_String(long value)
        {
            return value.ToStandardString();
        }

        [TestCase(ulong.MinValue, ExpectedResult = "0")]
        [TestCase(ulong.MaxValue, ExpectedResult = "18446744073709551615")]
        public string Unsigned_64bit_Integer_To_Standard_String(ulong value)
        {
            return value.ToStandardString();
        }

        [TestCase(123f, ExpectedResult = "123")]
        [TestCase(123.456f, ExpectedResult = "123.456")]
        [TestCase(float.MaxValue, ExpectedResult = "3.402823E+38")]
        [TestCase(float.MinValue, ExpectedResult = "-3.402823E+38")]
        [TestCase(float.Epsilon, ExpectedResult = "1.401298E-45")]
        [TestCase(float.PositiveInfinity, ExpectedResult = "Infinity")]
        [TestCase(float.NegativeInfinity, ExpectedResult = "-Infinity")]
        [TestCase(float.NaN, ExpectedResult = "NaN")]
        public string Single_Precision_Float_To_Standard_String(float value)
        {
            return value.ToStandardString();
        }

        [TestCase(123, ExpectedResult = "123")]
        [TestCase(123.456, ExpectedResult = "123.456")]
        [TestCase(double.MaxValue, ExpectedResult = "1.79769313486232E+308")]
        [TestCase(double.MinValue, ExpectedResult = "-1.79769313486232E+308")]
        [TestCase(double.Epsilon, ExpectedResult = "4.94065645841247E-324")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "Infinity")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "-Infinity")]
        [TestCase(double.NaN, ExpectedResult = "NaN")]
        public string Double_Precision_Float_To_Standard_String(double value)
        {
            return value.ToStandardString();
        }

        static IEnumerable<TestCaseData> TestCases_For_Decimal_To_Standard_String()
        {
            yield return new TestCaseData(+79228162514264337593543950335m)
                .Returns("79228162514264337593543950335");
            yield return new TestCaseData(-79228162514264337593543950335m)
                .Returns("-79228162514264337593543950335");
            yield return new TestCaseData(0.1234567890123456789012345678m)
                .Returns("0.1234567890123456789012345678");
            yield return new TestCaseData(7.9228E+28m)
                .Returns("79228000000000000000000000000");
            yield return new TestCaseData(-7.9228E+28m)
                .Returns("-79228000000000000000000000000");
            yield return new TestCaseData(1E-28m)
                .Returns("0.0000000000000000000000000001");
            yield return new TestCaseData(-1E-28m)
                .Returns("-0.0000000000000000000000000001");
        }

        [TestCaseSource(nameof(TestCases_For_Decimal_To_Standard_String))]
        public string Decimal_To_Standard_String(decimal value)
        {
            return value.ToStandardString();
        }

        static IEnumerable<TestCaseData> TestCases_For_DateTime_To_Standard_String()
        {
            yield return new TestCaseData(new DateTime(0001, 01, 01, 00, 00, 00, DateTimeKind.Utc))
                .Returns("0001-01-01T00:00:00Z");
            yield return new TestCaseData(new DateTime(9999, 12, 31, 23, 59, 59, DateTimeKind.Utc))
                .Returns("9999-12-31T23:59:59Z");
            yield return new TestCaseData(new DateTime(2020, 06, 15, 12, 30, 45))
                .Returns("2020-06-15T12:30:45");
        }

        [TestCaseSource(nameof(TestCases_For_DateTime_To_Standard_String))]
        public string DateTime_To_Standard_String(DateTime value)
        {
            return value.ToStandardString();
        }

        static IEnumerable<TestCaseData> TestCases_For_DateTimeOffset_To_Standard_String()
        {
            yield return new TestCaseData(new DateTimeOffset(0001, 01, 01, 00, 00, 00, TimeSpan.Zero))
                .Returns("0001-01-01T00:00:00+00:00");
            yield return new TestCaseData(new DateTimeOffset(9999, 12, 31, 23, 59, 59, TimeSpan.Zero))
                .Returns("9999-12-31T23:59:59+00:00");
            yield return new TestCaseData(new DateTimeOffset(2020, 06, 15, 12, 30, 45, 999, TimeSpan.FromHours(+2.5)))
                .Returns("2020-06-15T12:30:45.999+02:30");
            yield return new TestCaseData(new DateTimeOffset(2020, 06, 15, 12, 30, 45, 999, TimeSpan.FromHours(-2.5)))
                .Returns("2020-06-15T12:30:45.999-02:30");
        }

        [TestCaseSource(nameof(TestCases_For_DateTimeOffset_To_Standard_String))]
        public string DateTimeOffset_To_Standard_String(DateTimeOffset value)
        {
            return value.ToStandardString();
        }

        static IEnumerable<TestCaseData> TestCases_For_Object_To_Standard_String()
        {
            yield return new TestCaseData(DayOfWeek.Friday)
                .Returns("5");
            yield return new TestCaseData(true)
                .Returns("true");
            yield return new TestCaseData(-123456789)
                .Returns("-123456789");
            yield return new TestCaseData(123456789.012345)
                .Returns("123456789.012345");
            yield return new TestCaseData(2.5E-27m)
                .Returns("0.0000000000000000000000000025");
            yield return new TestCaseData(new DateTime(4231, 12, 21, 12, 34, 56, 789, DateTimeKind.Utc))
                .Returns("4231-12-21T12:34:56.789Z");
            yield return new TestCaseData(new DateTimeOffset(4231, 12, 21, 12, 34, 56, 789, TimeSpan.FromHours(1)))
                .Returns("4231-12-21T12:34:56.789+01:00");
            yield return new TestCaseData(TimeSpan.FromHours(2.5))
                .Returns(TimeSpan.FromHours(2.5).ToString(null, CultureInfo.InvariantCulture));
        }

        [TestCaseSource(nameof(TestCases_For_Object_To_Standard_String))]
        public string Object_To_Standard_String(object value)
        {
            return value.ToStandardString();
        }
    }
}