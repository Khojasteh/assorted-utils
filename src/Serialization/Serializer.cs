// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using System;

namespace Assorted.Utils.Serialization
{
    /// <summary>
    /// This class provides access to the concrete and singleton instances of the <see cref="ISerializer"/> interface.
    /// </summary>
    /// <threadsafety/>
    public static class Serializer
    {
        /// <summary>
        /// Gets an instance of <see cref="XmlSerializer"/> class for serializing and deserializing objects
        /// into and from XML format.
        /// </summary>
        public static XmlSerializer XML => xmlSerializer.Value;

        /// <summary>
        /// Gets an instance of <see cref="JsonSerializer"/> class for serializing and deserializing objects
        /// into and from JSON format.
        /// </summary>
        public static JsonSerializer JSON => jsonSerializer.Value;

        /// <summary>
        /// Gets an instance of <see cref="BinarySerializer"/> class for serializing and deserializing objects
        /// into and from binary/base-64 format.
        /// </summary>
        public static BinarySerializer Binary => binarySerializer.Value;

        #region Private Fields

        private static readonly Lazy<XmlSerializer> xmlSerializer = new Lazy<XmlSerializer>();
        private static readonly Lazy<JsonSerializer> jsonSerializer = new Lazy<JsonSerializer>();
        private static readonly Lazy<BinarySerializer> binarySerializer = new Lazy<BinarySerializer>();

        #endregion
    }
}