using System;
using System.IO;
using System.Text;

namespace Assorted.Utils.Serialization
{
    /// <summary>
    /// Implements a <see cref="StringWriter"/> with UTF-8 encoding.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    public class Utf8StringWriter: StringWriter
    {
        /// <overloads>
        /// Initializes a new instance of the <see cref="Utf8StringWriter"/> class.
        /// </overloads>
        /// <summary>
        /// Initializes a new instance of the <see cref="Utf8StringWriter"/> class.
        /// </summary>
        public Utf8StringWriter() 
            : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Utf8StringWriter"/> class with the specified
        /// format control.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> object that controls formatting.</param>
        public Utf8StringWriter(IFormatProvider formatProvider)
            : base(formatProvider) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Utf8StringWriter"/> class that writes to
        /// the specified <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="sb">The <see cref="StringBuilder"/> object to write to.</param>
        /// <exception cref="ArgumentNullException"><paramref name="sb"/> is <see langword="null"/>.</exception>
        public Utf8StringWriter(StringBuilder sb)
            : base(sb) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Utf8StringWriter"/> class that writes to
        /// the specified <see cref="StringBuilder"/> and has the specified format provider.
        /// </summary>
        /// <param name="sb">The <see cref="StringBuilder"/> object to write to.</param>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> object that controls formatting.</param>
        /// <exception cref="ArgumentNullException"><paramref name="sb"/> is <see langword="null"/>.</exception>
        public Utf8StringWriter(StringBuilder sb, IFormatProvider formatProvider)
            : base(sb, formatProvider) { }

        /// <summary>
        /// Gets the <see cref="Encoding"/> in which the output is written. 
        /// </summary>
        /// <value>
        /// The <see cref="Encoding"/> of a <see cref="Utf8StringWriter"/> object is always <see cref="Encoding.UTF8"/>.
        /// </value>
        public override Encoding Encoding => Encoding.UTF8;
    }
}