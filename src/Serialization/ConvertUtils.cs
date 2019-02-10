using System;
using System.Globalization;
using System.Linq;

namespace Assorted.Utils.Serialization
{
    /// <summary>
    /// Provides some helper methods for converting primitive values from their culture independent string representation.
    /// </summary>
    /// <threadsafety/>
    public static class ConvertUtils
    {
        /// <summary>
        /// Converts the specified standard string representation of an enumerated constant to its 
        /// <see cref="Enum"/> equivalent. The leading and trailing white spaces are ignored.
        /// </summary>
        /// <typeparam name="TEnum">The enumeration type to which to convert value.</typeparam>
        /// <param name="value">The string representation of an enumeration name or its underlying value.</param>
        /// <returns>
        /// An <see cref="Enum"/> of type <typeparamref name="TEnum"/> whose value is represented 
        /// by <paramref name="value"/> if the operation succeeds; otherwise, <see langword="null"/>.
        /// </returns>
        public static TEnum? StrToEnum<TEnum>(string value)
           where TEnum : struct, IConvertible
        {
            if (Enum.TryParse<TEnum>(value, true, out var result))
            {
                var type = typeof(TEnum);
                if (type.IsEnumDefined(result) || type.CustomAttributes.Any(ca => typeof(FlagsAttribute).Equals(ca.AttributeType)))
                    return result;
            }

            return null;
        }

        /// <summary>
        /// Converts the specified standard string representation of a logical value to its <see cref="bool"/>
        /// equivalent. The leading and trailing white spaces are ignored.
        /// </summary>
        /// <param name="value">The string representation of a logical value.</param>
        /// <returns>
        /// A boolean whose value is represented by <paramref name="value"/> if the operation succeeds; 
        /// otherwise, <see langword="null"/>.
        /// </returns>
        public static bool? StrToBool(string value)
        {
            switch (value?.Trim().ToLowerInvariant())
            {
                case "false":
                case "0":
                    return false;
                case "true":
                case "1":
                    return true;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Converts the specified standard string representation of an integer number to its <see cref="sbyte"/>
        /// equivalent. The leading and trailing white spaces are ignored.
        /// </summary>
        /// <param name="value">The string representation of an integer value.</param>
        /// <returns>
        /// A signed 8-bit integer number whose value is represented by <paramref name="value"/> if 
        /// the operation succeeds; otherwise, <see langword="null"/>.
        /// </returns>
        public static sbyte? StrToInt8(string value)
        {
            if (sbyte.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Converts the specified standard string representation of an integer number to its <see cref="byte"/>
        /// equivalent. The leading and trailing white spaces are ignored.
        /// </summary>
        /// <param name="value">The string representation of an integer value.</param>
        /// <returns>
        /// An 8-bit unsigned integer number whose value is represented by <paramref name="value"/> if
        /// the operation succeeds; otherwise, <see langword="null"/>.
        /// </returns>
        public static byte? StrToUInt8(string value)
        {
            if (byte.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Converts the specified standard string representation of an integer number to its <see cref="short"/>
        /// equivalent. The leading and trailing white spaces are ignored.
        /// </summary>
        /// <param name="value">The string representation of an integer value.</param>
        /// <returns>
        /// A 16-bit signed integer number whose value is represented by <paramref name="value"/> if
        /// the operation succeeds; otherwise, <see langword="null"/>.
        /// </returns>
        public static short? StrToInt16(string value)
        {
            if (short.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Converts the specified standard string representation of an integer number to its <see cref="ushort"/>
        /// equivalent. The leading and trailing white spaces are ignored.
        /// </summary>
        /// <param name="value">The string representation of an integer value.</param>
        /// <returns>
        /// An unsigned 16-bit integer number whose value is represented by <paramref name="value"/> if
        /// the operation succeeds; otherwise, <see langword="null"/>.
        /// </returns>
        public static ushort? StrToUInt16(string value)
        {
            if (ushort.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Converts the specified standard string representation of an integer number to its <see cref="int"/>
        /// equivalent. The leading and trailing white spaces are ignored.
        /// </summary>
        /// <param name="value">The string representation of an integer value.</param>
        /// <returns>
        /// A 32-bit signed integer number whose value is represented by <paramref name="value"/> if
        /// the operation succeeds; otherwise, <see langword="null"/>.
        /// </returns>
        public static int? StrToInt32(string value)
        {
            if (int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Converts the specified standard string representation of an integer number to its <see cref="uint"/>
        /// equivalent. The leading and trailing white spaces are ignored.
        /// </summary>
        /// <param name="value">The string representation of an integer value.</param>
        /// <returns>
        /// An unsigned 32-bit integer number whose value is represented by <paramref name="value"/> if
        /// the operation succeeds; otherwise, <see langword="null"/>.
        /// </returns>
        public static uint? StrToUInt32(string value)
        {
            if (uint.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Converts the specified standard string representation of an integer number to its <see cref="long"/>
        /// equivalent. The leading and trailing white spaces are ignored.
        /// </summary>
        /// <param name="value">The string representation of an integer value.</param>
        /// <returns>
        /// A 64-bit signed integer number whose value is represented by <paramref name="value"/> if
        /// the operation succeeds; otherwise, <see langword="null"/>.
        /// </returns>
        public static long? StrToInt64(string value)
        {
            if (long.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Converts the specified standard string representation of an integer number to its <see cref="ulong"/>
        /// equivalent. The leading and trailing white spaces are ignored.
        /// </summary>
        /// <param name="value">The string representation of an integer value.</param>
        /// <returns>
        /// An unsigned 64-bit integer number whose value is represented by <paramref name="value"/> if
        /// the operation succeeds; otherwise, <see langword="null"/>.
        /// </returns>
        public static ulong? StrToUInt64(string value)
        {
            if (ulong.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Converts the specified standard string representation of a real number to its <see cref="float"/>
        /// equivalent. The leading and trailing white spaces are ignored.
        /// </summary>
        /// <param name="value">The string representation of a real value.</param>
        /// <returns>
        /// A single-precision floating-point number whose value is represented by <paramref name="value"/> 
        /// if the operation succeeds; otherwise, <see langword="null"/>.
        /// </returns>
        public static float? StrToSingle(string value)
        {
            if (float.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Converts the specified standard string representation of a real number to its <see cref="double"/>
        /// equivalent. The leading and trailing white spaces are ignored.
        /// </summary>
        /// <param name="value">The string representation of a real value.</param>
        /// <returns>
        /// A double-precision floating-point number whose value is represented by <paramref name="value"/> 
        /// if the operation succeeds; otherwise, <see langword="null"/>.
        /// </returns>
        public static double? StrToDouble(string value)
        {
            if (double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Converts the specified standard string representation of a real number to its <see cref="decimal"/>
        /// equivalent. The leading and trailing white spaces are ignored.
        /// </summary>
        /// <param name="value">The string representation of a real value.</param>
        /// <returns>
        /// A decimal number whose value is represented by <paramref name="value"/> if the operation succeeds; 
        /// otherwise, <see langword="null"/>.
        /// </returns>
        public static decimal? StrToDecimal(string value)
        {
            if (decimal.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Converts the specified standard string representation of a date to its <see cref="DateTime"/>
        /// equivalent. The leading and trailing white spaces are ignored.
        /// </summary>
        /// <param name="value">The string representation of a date in <c>"yyyy'-'MM'-'dd"</c> format.</param>
        /// <returns>
        /// A <see cref="DateTime"/> whose value is represented by <paramref name="value"/> if the operation 
        /// succeeds; otherwise, <see langword="null"/>.
        /// </returns>
        public static DateTime? StrToDate(string value)
        {
            if (DateTime.TryParseExact(value, "yyyy'-'MM'-'dd", CultureInfo.InvariantCulture,
                DateTimeStyles.None | DateTimeStyles.AllowLeadingWhite | DateTimeStyles.AllowTrailingWhite,
                out var result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// Converts the specified standard string representation of a time to its <see cref="DateTime"/>
        /// equivalent. The leading and trailing white spaces are ignored.
        /// </summary>
        /// <param name="value">
        /// The string representation of a time in one of these formats:
        /// <list type="bullet">
        /// <item><description><c>"HH':'mm':'ss'.'FFFFFFF"</c></description></item>
        /// <item><description><c>"HH':'mm':'ss"</c></description></item>
        /// </list>
        /// </param>
        /// <returns>
        /// A <see cref="DateTime"/> whose value is represented by <paramref name="value"/> if the operation 
        /// succeeds; otherwise, <see langword="null"/>.
        /// </returns>
        public static DateTime? StrToTime(string value)
        {
            var acceptedFormats = new[] {
                "HH':'mm':'ss'.'FFFFFFF",
                "HH':'mm':'ss",
            };

            if (DateTime.TryParseExact(value, acceptedFormats, CultureInfo.InvariantCulture,
                DateTimeStyles.NoCurrentDateDefault | DateTimeStyles.AllowLeadingWhite | DateTimeStyles.AllowTrailingWhite,
                out var result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// Converts the specified standard string representation of a date and time to its <see cref="DateTime"/> 
        /// equivalent. The leading and trailing white spaces are ignored.
        /// </summary>
        /// <param name="value">
        /// The string representation of a date and time in one of these formats:
        /// <list type="bullet">
        /// <item><description><c>"yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'FFFFFFFK"</c></description></item>
        /// <item><description><c>"yyyy'-'MM'-'dd'T'HH':'mm':'ssK"</c></description></item>
        /// <item><description><c>"yyyy'-'MM'-'dd'T'HH':'mm':'ss"</c></description></item>
        /// <item><description><c>"yyyy'-'MM'-'dd HH':'mm':'ss"</c></description></item>
        /// <item><description><c>"r"</c> (RFC1123)</description></item>
        /// </list>
        /// </param>
        /// <returns>
        /// A <see cref="DateTime"/> whose value is represented by <paramref name="value"/> if the operation 
        /// succeeds; otherwise, <see langword="null"/>.
        /// </returns>
        public static DateTime? StrToDateTime(string value)
        {
            var acceptedFormats = new[] {
                "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'FFFFFFFK",
                "yyyy'-'MM'-'dd'T'HH':'mm':'ssK",
                "yyyy'-'MM'-'dd'T'HH':'mm':'ss",
                "yyyy'-'MM'-'dd HH':'mm':'ss",
                "r",
            };

            if (DateTime.TryParseExact(value, acceptedFormats, CultureInfo.InvariantCulture,
                DateTimeStyles.AdjustToUniversal | DateTimeStyles.AllowLeadingWhite | DateTimeStyles.AllowTrailingWhite,
                out var result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// Converts the specified standard string representation of a date and/or time to its <see cref="DateTimeOffset"/>
        /// equivalent. The leading and trailing white spaces are ignored.
        /// </summary>
        /// <param name="value">
        /// The string representation of a date and time in one of these formats:
        /// <list type="bullet">
        /// <item><description><c>"yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'FFFFFFFK"</c></description></item>
        /// <item><description><c>"yyyy'-'MM'-'dd'T'HH':'mm':'ssK"</c></description></item>
        /// <item><description><c>"yyyy'-'MM'-'dd'T'HH':'mm':'ss"</c></description></item>
        /// <item><description><c>"yyyy'-'MM'-'dd HH':'mm':'ss"</c></description></item>
        /// <item><description><c>"r"</c> (RFC1123)</description></item>
        /// </list>
        /// </param>
        /// <returns>
        /// A <see cref="DateTimeOffset"/> whose value is represented by <paramref name="value"/> if the operation 
        /// succeeds; otherwise, <see langword="null"/>.
        /// </returns>
        public static DateTimeOffset? StrToDateTimeOffset(string value)
        {
            var acceptedFormats = new[] {
                "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'FFFFFFFK",
                "yyyy'-'MM'-'dd'T'HH':'mm':'ssK",
                "yyyy'-'MM'-'dd'T'HH':'mm':'ss",
                "yyyy'-'MM'-'dd HH':'mm':'ss",
                "r",
            };

            if (DateTimeOffset.TryParseExact(value, acceptedFormats, CultureInfo.InvariantCulture,
                DateTimeStyles.RoundtripKind | DateTimeStyles.AllowLeadingWhite | DateTimeStyles.AllowTrailingWhite,
                out var result))
            {
                return result;
            }

            return null;
        }
    }
}
