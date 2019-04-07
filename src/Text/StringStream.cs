// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using System;
using System.IO;

namespace Assorted.Utils.Text
{
    /// <summary>
    /// Creates a stream whose backing store is string.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    public class StringStream : MemoryStream
    {
        /// <overloads>
        /// Initializes a new instance of <see cref="StringStream"/> class.
        /// </overloads>
        /// <summary>
        /// Initializes a new instance of <see cref="StringStream"/> class with an expandable capacity
        /// using the specified encoding.
        /// </summary>
        public StringStream()
            : this(System.Text.Encoding.UTF8) { }

        /// <summary>
        /// Initializes a new instance of <see cref="StringStream"/> class with an expandable capacity
        /// using the <see cref="System.Text.Encoding.UTF8"/> encoding.
        /// </summary>
        /// <param name="encoding">
        /// The character encoding to use. If a <see langword="null"/> value is passed as this parameter,
        /// the <see cref="System.Text.Encoding.UTF8"/> encoding will be used.
        /// </param>
        public StringStream(System.Text.Encoding encoding)
            : base()
        {
            Encoding = encoding ?? System.Text.Encoding.UTF8;
        }

        /// <summary>
        /// Initializes a new a new non-resizable instance of <see cref="StringStream"/> class based on
        /// the specified string and using the <see cref="System.Text.Encoding.UTF8"/> encoding.
        /// </summary>
        /// <param name="value">
        /// The string from which to create this stream. Passing a <see langword="null"/> value as this
        /// parameter will create an empty stream.
        /// </param>
        public StringStream(string value)
            : this(value, System.Text.Encoding.UTF8) { }

        /// <summary>
        /// Initializes a new a new non-resizable instance of <see cref="StringStream"/> class based on
        /// the specified string and using the specified encoding.
        /// </summary>
        /// <param name="value">
        /// The string from which to create this stream. Passing a <see langword="null"/> value as this
        /// parameter will create an empty stream.
        /// </param>
        /// <param name="encoding">
        /// The character encoding to use. If a <see langword="null"/> value is passed as this parameter,
        /// the <see cref="System.Text.Encoding.UTF8"/> encoding will be used.
        /// </param>
        public StringStream(string value, System.Text.Encoding encoding)
            : base(string.IsNullOrEmpty(value) ? Array.Empty<byte>() : (encoding ?? System.Text.Encoding.UTF8).GetBytes(value))
        {
            Encoding = encoding ?? System.Text.Encoding.UTF8;
        }

        /// <summary>
        /// Gets the text encoding in which the output is written.
        /// </summary>
        public System.Text.Encoding Encoding { get; }

        /// <summary>
        /// Returns a string containing the characters written to the current stream so far.
        /// </summary>
        /// <returns>The string representing the data contained by the <see cref="StringStream"/> object.</returns>
        public override string ToString()
        {
            return Encoding.GetString(ToArray());
        }
    }
}
