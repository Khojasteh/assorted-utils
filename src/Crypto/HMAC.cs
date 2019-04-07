// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using System;

namespace Assorted.Utils.Crypto
{
    /// <summary>
    /// This class provides access to the concrete and singleton instances of the <see cref="KeyedHasher"/> class
    /// for the most common HMAC hashing algorithms.
    /// </summary>
    /// <threadsafety/>
    public static class HMAC
    {
        /// <summary>
        /// Gets an instance of MD5 keyed-hash (HMAC) algorithm.
        /// </summary>
        /// <seealso cref="KeyedHasher"/>
        public static KeyedHasher MD5 => md5.Value;

        /// <summary>
        /// Gets an instance of SHA-1 keyed-hash (HMAC) algorithm.
        /// </summary>
        /// <seealso cref="KeyedHasher"/>
        public static KeyedHasher SHA1 => sha1.Value;

        /// <summary>
        /// Gets an instance of SHA-256 keyed-hash (HMAC) algorithm.
        /// </summary>
        /// <seealso cref="KeyedHasher"/>
        public static KeyedHasher SHA256 => sha256.Value;

        /// <summary>
        /// Gets an instance of SHA-384 keyed-hash (HMAC) algorithm.
        /// </summary>
        /// <seealso cref="KeyedHasher"/>
        public static KeyedHasher SHA384 => sha384.Value;

        /// <summary>
        /// Gets an instance of SHA-512 keyed-hash (HMAC) algorithm.
        /// </summary>
        /// <seealso cref="KeyedHasher"/>
        public static KeyedHasher SHA512 => sha512.Value;

        #region Private Fields

        private static readonly Lazy<KeyedHasher> md5 =
            new Lazy<KeyedHasher>(() => new KeyedHasherProxy(() => System.Security.Cryptography.HMAC.Create("HMACMD5")));

        private static readonly Lazy<KeyedHasher> sha1 =
            new Lazy<KeyedHasher>(() => new KeyedHasherProxy(() => System.Security.Cryptography.HMAC.Create("HMACSHA1")));

        private static readonly Lazy<KeyedHasher> sha256 =
            new Lazy<KeyedHasher>(() => new KeyedHasherProxy(() => System.Security.Cryptography.HMAC.Create("HMACSHA256")));

        private static readonly Lazy<KeyedHasher> sha384 =
            new Lazy<KeyedHasher>(() => new KeyedHasherProxy(() => System.Security.Cryptography.HMAC.Create("HMACSHA384")));

        private static readonly Lazy<KeyedHasher> sha512 =
            new Lazy<KeyedHasher>(() => new KeyedHasherProxy(() => System.Security.Cryptography.HMAC.Create("HMACSHA512")));

        #endregion
    }
}
