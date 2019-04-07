// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using System;

namespace Assorted.Utils.Crypto
{
    /// <summary>
    /// Converts an array of bytes to and from a string of hexadecimal digits.
    /// </summary>
    /// <threadsafety/>
    public static class ByteConvert
    {
        private const byte INVALID_HEX_CHAR = 255;

        private static readonly char[] ByteToHex;
        private static readonly byte[] HexToByte;

        static ByteConvert()
        {
            ByteToHex = new char[16];
            HexToByte = new byte[256];
            for (var i = 0; i < 256; ++i)
                HexToByte[i] = INVALID_HEX_CHAR;
            for (byte i = 0; i <= 9; ++i)
            {
                ByteToHex[i] = (char)('0' + i);
                HexToByte['0' + i] = i;
            }
            for (byte i = 10, k = 0; i <= 15; ++i, ++k)
            {
                ByteToHex[i] = (char)('a' + k);
                HexToByte['a' + k] = i;
                HexToByte['A' + k] = i;
            }
        }

        /// <summary>
        /// Converts the numeric value of each element of a specified array of bytes to its equivalent
        /// hexadecimal string representation.
        /// </summary>
        /// <param name="bytes">An array of bytes.</param>
        /// <returns>
        /// A string of hexadecimal pairs, where each pair represents the corresponding element in
        /// the <paramref name="bytes"/> array.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="bytes"/> is <see langword="null"/>.</exception>
        public static string ToHex(byte[] bytes)
        {
            Contract.Requires<ArgumentNullException>(bytes != null, nameof(bytes));

            if (bytes.Length == 0)
                return string.Empty;

            var hex = new char[bytes.Length << 1];
            for (int i = 0, k = 0; i < bytes.Length; ++i)
            {
                var b = bytes[i];
                hex[k++] = ByteToHex[b >> 4];
                hex[k++] = ByteToHex[b & 15];
            }

            return new string(hex);
        }

        /// <summary>
        /// Converts a hexadecimal string to its equivalent array of bytes.
        /// </summary>
        /// <param name="hex">A string of hexadecimal digits.</param>
        /// <returns>An array of bytes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="hex"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException"><paramref name="hex"/> is not in a valid format.</exception>
        public static byte[] FromHex(string hex)
        {
            Contract.Requires<ArgumentNullException>(hex != null, nameof(hex));
            Contract.Requires<FormatException>((hex.Length & 1) == 0, nameof(hex));

            if (hex.Length == 0)
                return Array.Empty<byte>();

            var bytes = new byte[hex.Length >> 1];
            for (int i = 0, k = 0; i < bytes.Length; i++)
            {
                var hi = HexToByte[hex[k++]];
                var lo = HexToByte[hex[k++]];

                if (hi == INVALID_HEX_CHAR || lo == INVALID_HEX_CHAR)
                    throw new FormatException();

                bytes[i] = (byte)((hi << 4) | lo);
            }

            return bytes;
        }
    }
}
