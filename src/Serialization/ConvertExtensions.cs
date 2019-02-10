using System;
using System.Globalization;
using System.Linq;

namespace Assorted.Utils.Serialization
{
    /// <summary>
    /// Extends primitive data types by adding the <c>ToStandardString()</c> method to them. 
    /// The method returns the string representation of the extended objects in culture independent format.
    /// </summary>
    /// <threadsafety/>
    public static class ConvertExtensions
    {
        /// <summary>
        /// Returns the standard string representation of the underlying numeric value of the specified 
        /// enumeration value.
        /// </summary>
        /// <param name="value">The enumeration value to represent as string.</param>
        /// <returns>The standard string representation of the specified <paramref name="value"/>.</returns>
        public static string ToStandardString(this Enum value)
        {
            return value.ToString("D");
        }

        /// <summary>
        /// Returns the standard string representation of the specified logical value.
        /// </summary>
        /// <param name="value">The logical value to represent as string.</param>
        /// <returns>The standard string representation of the specified <paramref name="value"/>.</returns>
        public static string ToStandardString(this bool value)
        {
            return value ? "true" : "false";
        }

        /// <summary>
        /// Returns the standard string representation of the specified integer value.
        /// </summary>
        /// <param name="value">The integer value to represent as string.</param>
        /// <returns>The standard string representation of the specified <paramref name="value"/>.</returns>
        public static string ToStandardString(this sbyte value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns the standard string representation of the specified integer value.
        /// </summary>
        /// <param name="value">The integer value to represent as string.</param>
        /// <returns>The standard string representation of the specified <paramref name="value"/>.</returns>
        public static string ToStandardString(this byte value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns the standard string representation of the specified integer value.
        /// </summary>
        /// <param name="value">The integer value to represent as string.</param>
        /// <returns>The standard string representation of the specified <paramref name="value"/>.</returns>
        public static string ToStandardString(this ushort value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns the standard string representation of the specified integer value.
        /// </summary>
        /// <param name="value">The integer value to represent as string.</param>
        /// <returns>The standard string representation of the specified <paramref name="value"/>.</returns>
        public static string ToStandardString(this short value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns the standard string representation of the specified integer value.
        /// </summary>
        /// <param name="value">The integer value to represent as string.</param>
        /// <returns>The standard string representation of the specified <paramref name="value"/>.</returns>
        public static string ToStandardString(this uint value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns the standard string representation of the specified integer value.
        /// </summary>
        /// <param name="value">The integer value to represent as string.</param>
        /// <returns>The standard string representation of the specified <paramref name="value"/>.</returns>
        public static string ToStandardString(this int value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns the standard string representation of the specified integer value.
        /// </summary>
        /// <param name="value">The integer value to represent as string.</param>
        /// <returns>The standard string representation of the specified <paramref name="value"/>.</returns>
        public static string ToStandardString(this ulong value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns the standard string representation of the specified integer value.
        /// </summary>
        /// <param name="value">The integer value to represent as string.</param>
        /// <returns>The standard string representation of the specified <paramref name="value"/>.</returns>
        public static string ToStandardString(this long value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns the standard string representation of the specified floating point value.
        /// </summary>
        /// <param name="value">The floating point value to represent as string.</param>
        /// <returns>The standard string representation of the specified <paramref name="value"/>.</returns>
        public static string ToStandardString(this float value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns the standard string representation of the specified floating point value.
        /// </summary>
        /// <param name="value">The floating point value to represent as string.</param>
        /// <returns>The standard string representation of the specified <paramref name="value"/>.</returns>
        public static string ToStandardString(this double value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns the standard string representation of the specified decimal value.
        /// </summary>
        /// <param name="value">The decimal value to represent as string.</param>
        /// <returns>The standard string representation of the specified <paramref name="value"/>.</returns>
        public static string ToStandardString(this decimal value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns the standard string representation of the specified <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="value">The <see cref="DateTime"/> value to represent as string.</param>
        /// <returns>The standard string representation of the specified <paramref name="value"/>.</returns>
        public static string ToStandardString(this DateTime value)
        {
            string format;
            if (value.Millisecond == 0)
                format = "yyyy'-'MM'-'dd'T'HH':'mm':'ssK";
            else
                format = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'FFFFFFFK";
            return value.ToString(format, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns the standard string representation of the specified <see cref="DateTimeOffset"/> value.
        /// </summary>
        /// <param name="value">The <see cref="DateTimeOffset"/> value to represent as string.</param>
        /// <returns>The standard string representation of the specified <paramref name="value"/>.</returns>
        public static string ToStandardString(this DateTimeOffset value)
        {
            string format;
            if (value.Millisecond == 0)
                format = "yyyy'-'MM'-'dd'T'HH':'mm':'ssK";
            else
                format = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'FFFFFFFK";
            return value.ToString(format, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns the standard string representation of the specified <see cref="object"/>.
        /// </summary>
        /// <param name="value">The <see cref="object"/> value to represent as string.</param>
        /// <returns>The standard string representation of the specified <paramref name="value"/>.</returns>
        public static string ToStandardString(this object value)
        {
            switch (value)
            {
                case null:
                    return null;
                case bool boolean:
                    return ToStandardString(boolean);
                case DateTime dateTime:
                    return ToStandardString(dateTime);
                case DateTimeOffset dateTimeOffset:
                    return ToStandardString(dateTimeOffset);
                case Enum enumerated:
                    return ToStandardString(enumerated);
                case IFormattable formattable:
                    return formattable.ToString(null, CultureInfo.InvariantCulture);
                default:
                    return value.ToString();
            }
        }

    }
}
