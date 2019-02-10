using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Assorted.Utils.Serialization
{
    /// <summary>
    /// Serializes and deserializes objects into and from JSON format.
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public class JsonSerializer : ISerializer
    {
        /// <summary>
        /// The default JSON serialization settings.
        /// </summary>
        public static readonly DataContractJsonSerializerSettings DefaultSettings =
            new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("u"),
                UseSimpleDictionaryFormat = true,
            };

        /// <summary>
        /// Gets the settings being used for JSON serialization.
        /// </summary>
        public DataContractJsonSerializerSettings Settings { get; }

        /// <overloads>
        /// Initializes a new instance of <see cref="JsonSerializer"/> class.
        /// </overloads>
        /// <summary>
        /// Initializes a new instance of <see cref="JsonSerializer"/> class with default settings.
        /// </summary>
        public JsonSerializer() : this(DefaultSettings) { }

        /// <summary>
        /// Initializes a new instance of <see cref="JsonSerializer"/> class with the specified settings.
        /// </summary>
        /// <param name="settings">The <see cref="DataContractJsonSerializerSettings"/> that contains JSON serialization settings.</param>
        /// <exception cref="ArgumentNullException"><paramref name="settings"/> is <see langword="null"/>.</exception>
        public JsonSerializer(DataContractJsonSerializerSettings settings)
        {
            Contract.Requires<ArgumentNullException>(settings != null, nameof(settings));

            Settings = settings;
        }

        /// <summary>
        /// Converts an object to its JSON representation.
        /// </summary>
        /// <typeparam name="T">The type of object to be serialized.</typeparam>
        /// <param name="graph">An object to be represented in JSON format.</param>
        /// <returns>The JSON representation of the specified object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="graph"/> is <see langword="null"/>.</exception>
        public string Serialize<T>(T graph)
        {
            Contract.Requires<ArgumentNullException>(graph != null, nameof(graph));

            using (var stream = new MemoryStream())
            {
                Serialize(graph, stream);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        /// <summary>
        /// Converts the JSON representation of an object to an instance of that object.
        /// </summary>
        /// <typeparam name="T">The type of object, which is represented in JSON format.</typeparam>
        /// <param name="json">The JSON representation of the object.</param>
        /// <returns>The deserialized object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="json"/> is <see langword="null"/>.</exception>
        public T Deserialize<T>(string json)
        {
            Contract.Requires<ArgumentNullException>(json != null, nameof(json));

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                return Deserialize<T>(stream);
            }
        }

        /// <summary>
        /// Serializes a given object and writes the JSON data into the specified <see cref="Stream"/>.
        /// </summary>
        /// <typeparam name="T">The type of object to be serialized.</typeparam>
        /// <param name="graph">An <see cref="object"/> to be represented in JSON format.</param>
        /// <param name="stream">A <see cref="Stream"/> object to write the JSON representation of the <paramref name="graph"/> into.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> or <paramref name="graph"/> is <see langword="null"/>.</exception>
        public virtual void Serialize<T>(T graph, Stream stream)
        {
            Contract.Requires<ArgumentNullException>(stream != null, nameof(stream));
            Contract.Requires<ArgumentNullException>(graph != null, nameof(graph));

            GetInternalSerializer<T>().WriteObject(stream, graph);
        }

        /// <summary>
        /// Deserializes the JSON data contained by the specified <see cref="Stream"/>.
        /// </summary>
        /// <typeparam name="T">The type of object to be deserialized.</typeparam>
        /// <param name="stream">A <see cref="Stream"/> object to read the JSON representation of the object from.</param>
        /// <returns>The deserialized object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is <see langword="null"/>.</exception>
        public virtual T Deserialize<T>(Stream stream)
        {
            Contract.Requires<ArgumentNullException>(stream != null, nameof(stream));

            return (T)GetInternalSerializer<T>().ReadObject(stream);
        }

        /// <summary>
        /// Creates an instance of <see cref="DataContractJsonSerializer"/> class for the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to create a serializer for.</typeparam>
        /// <returns>An instance of <see cref="DataContractJsonSerializer"/> class.</returns>
        protected virtual DataContractJsonSerializer GetInternalSerializer<T>()
        {
            return new DataContractJsonSerializer(typeof(T), Settings);
        }
    }
}