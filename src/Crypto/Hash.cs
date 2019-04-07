// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using System;

namespace Assorted.Utils.Crypto
{
    /// <summary>
    /// This class provides access to the concrete and singleton instances of the <see cref="Hasher"/> class
    /// for the most common hashing algorithms.
    /// </summary>
    /// <threadsafety/>
    public static class Hash
    {
        /// <summary>
        /// Gets an instance of MD5 hash algorithm.
        /// </summary>
        /// <seealso cref="Hasher"/>
        public static Hasher MD5 => md5.Value;

        /// <summary>
        /// Gets an instance of SHA-1 hash algorithm.
        /// </summary>
        /// <seealso cref="Hasher"/>
        public static Hasher SHA1 => sha1.Value;

        /// <summary>
        /// Gets an instance of SHA-256 hash algorithm.
        /// </summary>
        /// <seealso cref="Hasher"/>
        public static Hasher SHA256 => sha256.Value;

        /// <summary>
        /// Gets an instance of SHA-384 hash algorithm.
        /// </summary>
        /// <seealso cref="Hasher"/>
        public static Hasher SHA384 => sha384.Value;

        /// <summary>
        /// Gets an instance of SHA-512 hash algorithm.
        /// </summary>
        /// <seealso cref="Hasher"/>
        public static Hasher SHA512 => sha512.Value;

        #region Private Fields

        private static readonly Lazy<Hasher> md5 =
            new Lazy<Hasher>(() => new HasherProxy(System.Security.Cryptography.MD5.Create));

        private static readonly Lazy<Hasher> sha1 =
            new Lazy<Hasher>(() => new HasherProxy(System.Security.Cryptography.SHA1.Create));

        private static readonly Lazy<Hasher> sha256 =
            new Lazy<Hasher>(() => new HasherProxy(System.Security.Cryptography.SHA256.Create));

        private static readonly Lazy<Hasher> sha384 =
            new Lazy<Hasher>(() => new HasherProxy(System.Security.Cryptography.SHA384.Create));

        private static readonly Lazy<Hasher> sha512 =
            new Lazy<Hasher>(() => new HasherProxy(System.Security.Cryptography.SHA512.Create));

        #endregion
    }
}
