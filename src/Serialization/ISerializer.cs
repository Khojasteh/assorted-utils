using System;
using System.IO;

namespace Assorted.Utils.Serialization
{
    /// <summary>
    /// Represents an object that can serialize/deserialize other objects.
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Serializes an object as a string.
        /// </summary>
        /// <typeparam name="T">The type of object to be serialized.</typeparam>
        /// <param name="graph">The object to be serialized.</param>
        /// <returns>The serialized object as a string.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="graph"/> is <see langword="null"/>.</exception>
        string Serialize<T>(T graph);

        /// <summary>
        /// Deserializes an object serialized as a string into an instance of that object.
        /// </summary>
        /// <typeparam name="T">The type of object to be deserialized.</typeparam>
        /// <param name="serializedData">The serialization data.</param>
        /// <returns>The deserialized object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="serializedData"/> is <see langword="null"/>.</exception>
        T Deserialize<T>(string serializedData);

        /// <summary>
        /// Serializes an object into a stream.
        /// </summary>
        /// <typeparam name="T">The type of object to be serialized.</typeparam>
        /// <param name="graph">The object to be serialized.</param>
        /// <param name="stream">A stream to write the serialized data.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> or <paramref name="graph"/> is <see langword="null"/>.</exception>
        void Serialize<T>(T graph, Stream stream);

        /// <summary>
        /// Deserializes an object from a stream.
        /// </summary>
        /// <typeparam name="T">The type of object to be deserialized.</typeparam>
        /// <param name="stream">The source stream.</param>
        /// <returns>The deserialized object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is <see langword="null"/>.</exception>
        T Deserialize<T>(Stream stream);
    }
}