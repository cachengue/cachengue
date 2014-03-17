using System;

namespace Cachengue
{
    /// <summary>
    /// Defines the contract for the cache serializer
    /// </summary>
    public interface ICacheSerializer
    {
        /// <summary>
        /// Serializes the object
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The string representation of the serialized object
        /// </returns>
        string SerializeObject(string key, Type type, object value);

        /// <summary>
        /// Deserializes the string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="type">The type.</param>
        /// <param name="serialized">The serialized object.</param>
        /// <returns>
        /// The deserialized object
        /// </returns>
        object DeserializeObject(string key, Type type, string serialized);
    }
}