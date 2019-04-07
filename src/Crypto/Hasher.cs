// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using System;
using System.IO;
using System.Text;

namespace Assorted.Utils.Crypto
{
    /// <summary>
    /// Defines an abstract hash algorithm.
    /// </summary>
    public abstract class Hasher
    {
        /// <summary>
        /// Gets the size, in bits, of the computed hash code.
        /// </summary>
        public abstract int Size { get; }

        /// <overloads>
        /// Returns the hash code of a specific object.
        /// </overloads>
        /// <summary>
        /// Returns the hash code of content of the specified <see cref="Stream"/> object.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> object to calculate the hash code of its content.</param>
        /// <returns>The hash code of content of the <paramref name="stream"/> as an array of bytes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is <see langword="null"/>.</exception>
        public abstract byte[] Compute(Stream stream);

        /// <summary>
        /// Returns the hash code of the specified array of bytes.
        /// </summary>
        /// <param name="bytes">An array of bytes to calculate its hash code.</param>
        /// <returns>The hash code of the specified <paramref name="bytes"/> as an array of bytes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="bytes"/> is <see langword="null"/>.</exception>
        public virtual byte[] Compute(byte[] bytes)
        {
            Contract.Requires<ArgumentNullException>(bytes != null, nameof(bytes));

            using (var stream = new MemoryStream(bytes, writable: false))
                return Compute(stream);
        }

        /// <summary>
        /// Returns the hash code of the specified string.
        /// </summary>
        /// <param name="text">A <see cref="string"/> to calculate its hash code.</param>
        /// <returns>The hash code of the specified <paramref name="text"/> as an array of bytes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="text"/> is <see langword="null"/>.</exception>
        public byte[] Compute(string text)
        {
            Contract.Requires<ArgumentNullException>(text != null, nameof(text));

            return Compute(Encoding.UTF8.GetBytes(text));
        }
    }
}
