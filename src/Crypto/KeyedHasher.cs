using System;
using System.IO;
using System.Text;

namespace Assorted.Utils.Crypto
{
    /// <summary>
    /// Defines an abstract keyed-hash (HMAC) algorithm.
    /// </summary>
    public abstract class KeyedHasher
    {
        /// <summary>
        /// Gets the size, in bits, of the computed hash code.
        /// </summary>
        public abstract int Size { get; }

        /// <overloads>
        /// Returns the keyed-hash code of a specific object with a given secret key.
        /// </overloads>
        /// <summary>
        /// Returns the keyed-hash code of content of the specified stream. The secret key is an array of bytes.
        /// </summary>
        /// <param name="key">The secret key for encryption.</param>
        /// <param name="stream">A <see cref="Stream"/> object to calculate the keyed-hash code of its content.</param>
        /// <returns>The keyed-hash code of content of the specified <paramref name="stream"/> as an array of bytes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> or <paramref name="stream"/> is <see langword="null"/>.</exception>
        public abstract byte[] Compute(byte[] key, Stream stream);

        /// <summary>
        /// Returns the keyed-hash code of the specified <see cref="Stream"/> object. The secret key is a string.
        /// </summary>
        /// <param name="secret">The secret phrase.</param>
        /// <param name="stream">A <see cref="Stream"/> object to calculate the keyed-hash code of its content.</param>
        /// <returns>The keyed-hash code of content of the specified <paramref name="stream"/> content as an array of bytes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="secret"/> or <paramref name="stream"/> is <see langword="null"/>.
        /// </exception>
        public byte[] Compute(string secret, Stream stream)
        {
            Contract.Requires<ArgumentNullException>(secret != null, nameof(secret));
            Contract.Requires<ArgumentNullException>(stream != null, nameof(stream));

            return Compute(Encoding.UTF8.GetBytes(secret), stream);
        }

        /// <summary>
        /// Returns the keyed-hash code of the specified array of bytes. The secret key is an array of bytes.
        /// </summary>
        /// <param name="key">The secret key as an array of bytes.</param>
        /// <param name="bytes">An array of bytes to calculate its keyed-hash code.</param>
        /// <returns>The keyed-hash code of the specified <paramref name="bytes"/> as an array of bytes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> or <paramref name="bytes"/> is <see langword="null"/>.</exception>
        public virtual byte[] Compute(byte[] key, byte[] bytes)
        {
            Contract.Requires<ArgumentNullException>(key != null, nameof(key));
            Contract.Requires<ArgumentNullException>(bytes != null, nameof(bytes));

            using (var stream = new MemoryStream(bytes, writable: false))
                return Compute(key, stream);
        }

        /// <summary>
        /// Returns the keyed-hash code of the specified array of bytes. The secret key is a string.
        /// </summary>
        /// <param name="secret">The secret phrase.</param>
        /// <param name="bytes">An array of bytes to calculate its keyed-hash code.</param>
        /// <returns>The keyed-hash code of the specified <paramref name="bytes"/> as an array of bytes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="secret"/> or <paramref name="bytes"/> is <see langword="null"/>.
        /// </exception>
        public byte[] Compute(string secret, byte[] bytes)
        {
            Contract.Requires<ArgumentNullException>(secret != null, nameof(secret));
            Contract.Requires<ArgumentNullException>(bytes != null, nameof(bytes));

            return Compute(Encoding.UTF8.GetBytes(secret), bytes);
        }

        /// <summary>
        /// Returns the keyed-hash code of the specified string. The secret key is an array of bytes.
        /// </summary>
        /// <param name="key">The secret phrase.</param>
        /// <param name="text">A string to calculate its keyed-hash code.</param>
        /// <returns>The keyed-hash code of the specified <paramref name="text"/> as an array of bytes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> or <paramref name="text"/> is <see langword="null"/>.
        /// </exception>
        public byte[] Compute(byte[] key, string text)
        {
            Contract.Requires<ArgumentNullException>(key != null, nameof(key));
            Contract.Requires<ArgumentNullException>(text != null, nameof(text));

            return Compute(key, Encoding.UTF8.GetBytes(text));
        }

        /// <summary>
        /// Returns the keyed-hash code of the specified string. The secret key is a string.
        /// </summary>
        /// <param name="secret">The secret phrase.</param>
        /// <param name="text">A <see cref="string"/> to calculate its keyed-hash code.</param>
        /// <returns>The keyed-hash code of the specified <paramref name="text"/> as an array of bytes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="secret"/> or <paramref name="text"/> is <see langword="null"/>.
        /// </exception>
        public byte[] Compute(string secret, string text)
        {
            Contract.Requires<ArgumentNullException>(secret != null, nameof(secret));
            Contract.Requires<ArgumentNullException>(text != null, nameof(text));

            return Compute(Encoding.UTF8.GetBytes(secret), text);
        }
    }
}
