// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Assorted.Utils.Serialization
{
    /// <summary>
    /// Serializes and deserializes objects into and from XML documents.
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public class XmlSerializer : ISerializer
    {
        /// <summary>
        /// The default name-space for XML serialization, which is none.
        /// </summary>
        public static readonly XmlSerializerNamespaces DefaultNamespaces =
            new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName(string.Empty, string.Empty)
            });

        /// <summary>
        /// Gets the name-spaces being used for XML serialization.
        /// </summary>
        public XmlSerializerNamespaces Namespaces { get; }

        /// <overloads>
        /// Initializes a new instance of <see cref="XmlSerializer"/> class.
        /// </overloads>
        /// <summary>
        /// Initializes a new instance of <see cref="XmlSerializer"/> class without a name-space.
        /// </summary>
        public XmlSerializer() : this(DefaultNamespaces) { }

        /// <summary>
        /// Initializes a new instance of <see cref="XmlSerializer"/> class with the specified name-spaces.
        /// </summary>
        /// <param name="namespaces">The <see cref="XmlSerializerNamespaces"/> that contains name-spaces for the generated XML documents.</param>
        /// <exception cref="ArgumentNullException"><paramref name="namespaces"/> is <see langword="null"/>.</exception>
        public XmlSerializer(XmlSerializerNamespaces namespaces)
        {
            Contract.Requires<ArgumentNullException>(namespaces != null, nameof(namespaces));

            Namespaces = namespaces;
        }

        /// <summary>
        /// Converts an object to its XML representation.
        /// </summary>
        /// <typeparam name="T">The type of object to be serialized.</typeparam>
        /// <param name="graph">An object to be represented in XML format.</param>
        /// <returns>The XML representation of the specified object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="graph"/> is <see langword="null"/>.</exception>
        public string Serialize<T>(T graph)
        {
            Contract.Requires<ArgumentNullException>(graph != null, nameof(graph));

            using (var writer = new Utf8StringWriter())
            {
                Serialize(writer, graph);
                return writer.ToString();
            }
        }

        /// <summary>
        /// Converts the XML representation of an object to an instance of that object.
        /// </summary>
        /// <typeparam name="T">The type of object, which is represented in XML format.</typeparam>
        /// <param name="xml">The XML representation of the object.</param>
        /// <returns>The deserialized object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="xml"/> is <see langword="null"/>.</exception>
        public T Deserialize<T>(string xml)
        {
            Contract.Requires<ArgumentNullException>(xml != null, nameof(xml));

            using (var reader = new StringReader(xml))
            {
                return Deserialize<T>(reader);
            }
        }

        /// <summary>
        /// Serializes a given object and writes the XML document into the specified <see cref="Stream"/>.
        /// </summary>
        /// <typeparam name="T">The type of object to be serialized.</typeparam>
        /// <param name="graph">An <see cref="object"/> to be represented in XML format.</param>
        /// <param name="stream">A <see cref="Stream"/> object to write the XML representation of the <paramref name="graph"/> into.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> or <paramref name="graph"/> is <see langword="null"/>.</exception>
        public void Serialize<T>(T graph, Stream stream)
        {
            Contract.Requires<ArgumentNullException>(stream != null, nameof(stream));
            Contract.Requires<ArgumentNullException>(graph != null, nameof(graph));

            using (var writer = new StreamWriter(stream, Encoding.UTF8, 4096, true))
            {
                Serialize(writer, graph);
            }
        }

        /// <summary>
        /// Deserializes the XML document contained by the specified <see cref="Stream"/>.
        /// </summary>
        /// <typeparam name="T">The type of object to be deserialized.</typeparam>
        /// <param name="stream">A <see cref="Stream"/> object to read the XML representation of the object from.</param>
        /// <returns>The deserialized object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is <see langword="null"/>.</exception>
        public T Deserialize<T>(Stream stream)
        {
            Contract.Requires<ArgumentNullException>(stream != null, nameof(stream));

            using (var reader = new StreamReader(stream, Encoding.UTF8, true, 4096, true))
            {
                return Deserialize<T>(reader);
            }
        }

        /// <summary>
        /// Serializes a given object and writes the XML document into the specified <see cref="TextWriter"/>.
        /// </summary>
        /// <typeparam name="T">The type of object to be serialized.</typeparam>
        /// <param name="writer">A <see cref="TextWriter"/> object to write the XML representation of the <paramref name="graph"/> into.</param>
        /// <param name="graph">An <see cref="object"/> to be represented in XML format.</param>
        /// <exception cref="ArgumentNullException"><paramref name="writer"/> or <paramref name="graph"/> is <see langword="null"/>.</exception>
        public virtual void Serialize<T>(TextWriter writer, T graph)
        {
            Contract.Requires<ArgumentNullException>(writer != null, nameof(writer));
            Contract.Requires<ArgumentNullException>(graph != null, nameof(graph));

            GetInternalSerializer<T>().Serialize(writer, graph, Namespaces);
        }

        /// <summary>
        /// Deserializes the XML document contained by the specified <see cref="TextReader"/>.
        /// </summary>
        /// <typeparam name="T">The type of object, which is represented in XML format.</typeparam>
        /// <param name="reader">A <see cref="TextReader"/> object to read the XML representation of the object from.</param>
        /// <returns>The object being deserialized.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="reader"/> is <see langword="null"/>.</exception>
        public virtual T Deserialize<T>(TextReader reader)
        {
            Contract.Requires<ArgumentNullException>(reader != null, nameof(reader));

            return (T)GetInternalSerializer<T>().Deserialize(reader);
        }

        /// <summary>
        /// Creates an instance of <see cref="System.Xml.Serialization.XmlSerializer"/> class for the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to create a serializer for.</typeparam>
        /// <returns>An instance of <see cref="System.Xml.Serialization.XmlSerializer"/> class.</returns>
        protected virtual System.Xml.Serialization.XmlSerializer GetInternalSerializer<T>()
        {
            return new System.Xml.Serialization.XmlSerializer(typeof(T));
        }
    }
}