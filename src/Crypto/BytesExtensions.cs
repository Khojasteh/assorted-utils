// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using System;

namespace Assorted.Utils.Crypto
{
    /// <summary>
    /// Extends the array of bytes objects.
    /// </summary>
    /// <threadsafety/>
    public static class BytesExtensions
    {
        /// <summary>
        /// Converts the numeric value of each element of the array of bytes to its equivalent
        /// hexadecimal string representation.
        /// </summary>
        /// <param name="bytes">The source array of bytes.</param>
        /// <returns>
        /// A string of hexadecimal pairs, where each pair represents the corresponding element in
        /// the <paramref name="bytes"/> array.
        /// </returns>
        public static string ToHex(this byte[] bytes)
        {
            return (bytes != null) ? ByteConvert.ToHex(bytes) : null;
        }

        /// <summary>
        /// Converts the array of bytes to its equivalent string representation that is encoded with
        /// base-64 digits.
        /// </summary>
        /// <param name="bytes">An array of bytes.</param>
        /// <param name="options">Specifies whether to insert line breaks in the returned value.</param>
        /// <returns>The string representation, in base 64, of the contents of the <paramref name="bytes"/> array.</returns>
        public static string ToBase64(this byte[] bytes, Base64FormattingOptions options = Base64FormattingOptions.None)
        {
            return (bytes != null) ? Convert.ToBase64String(bytes, options) : null;
        }
    }
}
