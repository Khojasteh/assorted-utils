using System;
using System.IO;
using System.Security.Cryptography;

namespace Assorted.Utils.Crypto
{
    /// <summary>
    /// Wraps a .NET keyed-hash (HMAC) algorithm.
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public class KeyedHasherProxy : KeyedHasher
    {
        /// <summary>
        /// Initializes a new instances of <see cref="KeyedHasherProxy"/> class with the specified algorithm factory.
        /// </summary>
        /// <param name="algorithmFactory">A delegate that returns the implementation of a keyed-hash algorithm.</param>
        /// <exception cref="ArgumentNullException"><paramref name="algorithmFactory"/> is <see langword="null"/>.</exception>
        public KeyedHasherProxy(Func<KeyedHashAlgorithm> algorithmFactory)
        {
            Contract.Requires<ArgumentNullException>(algorithmFactory != null, nameof(algorithmFactory));

            AlgorithmFactory = algorithmFactory;
            using (var algorithm = AlgorithmFactory())
                Size = algorithm.HashSize;
        }

        /// <summary>
        /// Returns the keyed-hash code of content of a specified stream for the given secret key.
        /// </summary>
        /// <param name="key">The secret key for encryption.</param>
        /// <param name="stream">A <see cref="Stream"/> object to calculate the keyed-hash code of its content.</param>
        /// <returns>The keyed-hash code of content of the specified <paramref name="stream"/> as an array of bytes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> or <paramref name="stream"/> is <see langword="null"/>.</exception>
        public override byte[] Compute(byte[] key, Stream stream)
        {
            Contract.Requires<ArgumentNullException>(key != null, nameof(key));
            Contract.Requires<ArgumentNullException>(stream != null, nameof(stream));

            using (var algorithm = AlgorithmFactory())
            {
                algorithm.Key = key;
                return algorithm.ComputeHash(stream);
            }
        }

        /// <summary>
        /// Returns the keyed-hash code of a specified array of bytes for the given secret key.
        /// </summary>
        /// <param name="key">The secret key as an array of bytes.</param>
        /// <param name="bytes">An array of bytes to calculate its keyed-hash code.</param>
        /// <returns>The keyed-hash code of the specified <paramref name="bytes"/> as an array of bytes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> or <paramref name="bytes"/> is <see langword="null"/>.</exception>
        public override byte[] Compute(byte[] key, byte[] bytes)
        {
            Contract.Requires<ArgumentNullException>(key != null, nameof(key));
            Contract.Requires<ArgumentNullException>(bytes != null, nameof(bytes));

            using (var algorithm = AlgorithmFactory())
            {
                algorithm.Key = key;
                return algorithm.ComputeHash(bytes);
            }
        }

        /// <summary>
        /// Gets the size, in bits, of the computed hash code.
        /// </summary>
        public override int Size { get; }

        /// <summary>
        /// Gets the delegate that creates a hash algorithm.
        /// </summary>
        protected Func<KeyedHashAlgorithm> AlgorithmFactory { get; }
    }
}
