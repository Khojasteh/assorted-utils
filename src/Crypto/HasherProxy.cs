using System;
using System.IO;
using System.Security.Cryptography;

namespace Assorted.Utils.Crypto
{
    /// <summary>
    /// Wraps a .NET hash algorithm.
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public class HasherProxy : Hasher
    {
        /// <summary>
        /// Initializes a new instances of <see cref="HasherProxy"/> class with the specified algorithm factory.
        /// </summary>
        /// <param name="algorithmFactory">A delegate that returns the implementation of a hash algorithm.</param>
        /// <exception cref="ArgumentNullException"><paramref name="algorithmFactory"/> is <see langword="null"/>.</exception>
        public HasherProxy(Func<HashAlgorithm> algorithmFactory)
        {
            Contract.Requires<ArgumentNullException>(algorithmFactory != null, nameof(algorithmFactory));

            AlgorithmFactory = algorithmFactory;
            using (var algorithm = AlgorithmFactory())
                Size = algorithm.HashSize;
        }

        /// <summary>
        /// Returns the hash code of content of a specified stream.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> object to calculate the hash code of its content.</param>
        /// <returns>The hash code of content of the <paramref name="stream"/> as an array of bytes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is <see langword="null"/>.</exception>
        public override byte[] Compute(Stream stream)
        {
            Contract.Requires<ArgumentNullException>(stream != null, nameof(stream));

            using (var algorithm = AlgorithmFactory())
                return algorithm.ComputeHash(stream);
        }

        /// <summary>
        /// Returns the hash code of a specified array of bytes.
        /// </summary>
        /// <param name="bytes">An array of bytes to calculate its hash code.</param>
        /// <returns>The hash code of the specified <paramref name="bytes"/> as an array of bytes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="bytes"/> is <see langword="null"/>.</exception>
        public override byte[] Compute(byte[] bytes)
        {
            Contract.Requires<ArgumentNullException>(bytes != null, nameof(bytes));

            using (var algorithm = AlgorithmFactory())
                return algorithm.ComputeHash(bytes);
        }

        /// <summary>
        /// Gets the size, in bits, of the computed hash code.
        /// </summary>
        public override int Size { get; }

        /// <summary>
        /// Gets the delegate that creates a hash algorithm.
        /// </summary>
        protected Func<HashAlgorithm> AlgorithmFactory { get; }
    }
}
