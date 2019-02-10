using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assorted.Utils.Serialization
{
    /// <summary>
    /// Serializes and deserializes objects into and from binary/base-64 format.
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public class BinarySerializer: ISerializer
    {
        /// <summary>
        /// Initializes a new instance of <see cref="BinarySerializer"/> class.
        /// </summary>
        public BinarySerializer() {}

        /// <summary>
        /// Converts an object to its binary representation in base-64 format.
        /// </summary>
        /// <typeparam name="T">The type of object to be serialized.</typeparam>
        /// <param name="graph">An object to be represented in base-64 format.</param>
        /// <returns>The binary representation of the specified object in base-64 format.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="graph"/> is <see langword="null"/>.</exception>
        public string Serialize<T>(T graph)
        {
            Contract.Requires<ArgumentNullException>(graph != null, nameof(graph));

            using (var stream = new MemoryStream())
            {
                Serialize(graph, stream);
                return Convert.ToBase64String(stream.ToArray());
            }
        }

        /// <summary>
        /// Converts the binary representation of an object, provided in base-64 format, to an instance of that object.
        /// </summary>
        /// <typeparam name="T">The type of object to be deserialized.</typeparam>
        /// <param name="base64">The binary representation of the object in base-64 format.</param>
        /// <returns>The deserialized object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="base64"/> is <see langword="null"/>.</exception>
        public T Deserialize<T>(string base64)
        {
            Contract.Requires<ArgumentNullException>(base64 != null, nameof(base64));

            using (var stream = new MemoryStream(Convert.FromBase64String(base64)))
            {
                return Deserialize<T>(stream);
            }
        }

        /// <summary>
        /// Serializes a given object and writes the binary data into the specified <see cref="Stream"/>.
        /// </summary>
        /// <typeparam name="T">The type of object to be serialized.</typeparam>
        /// <param name="graph">An <see cref="object"/> to be serialized.</param>
        /// <param name="stream">A <see cref="Stream"/> object to write the binary representation of the <paramref name="graph"/> into.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> or <paramref name="graph"/> is <see langword="null"/>.</exception>
        public virtual void Serialize<T>(T graph, Stream stream)
        {
            Contract.Requires<ArgumentNullException>(stream != null, nameof(stream));
            Contract.Requires<ArgumentNullException>(graph != null, nameof(graph));

            GetInternalSerializer<T>().Serialize(stream, graph);
        }

        /// <summary>
        /// Deserializes the binary data contained by the specified <see cref="Stream"/>.
        /// </summary>
        /// <typeparam name="T">The type of object to be deserialized.</typeparam>
        /// <param name="stream">A <see cref="Stream"/> object to read the binary representation of the object from.</param>
        /// <returns>The deserialized object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is <see langword="null"/>.</exception>
        public virtual T Deserialize<T>(Stream stream)
        {
            Contract.Requires<ArgumentNullException>(stream != null, nameof(stream));

            return (T)GetInternalSerializer<T>().Deserialize(stream);
        }

        /// <summary>
        /// Creates an instance of <see cref="BinaryFormatter"/> class.
        /// </summary>
        /// <typeparam name="T">The type of object to create a serializer for.</typeparam>
        /// <returns>An instance of <see cref="BinaryFormatter"/> class.</returns>
        protected virtual BinaryFormatter GetInternalSerializer<T>()
        {
            return new BinaryFormatter();
        }
    }
}